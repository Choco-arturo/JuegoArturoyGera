using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class movimientoJugador : MonoBehaviour
{
    private Rigidbody2D rb2D;

    [Header("Movimiento")]

    private float inputX;

    private float movimientoHorizontal = 0f;

    [SerializeField] private float velocidadDeMovimiento;
    [Range (0, 0.3f)] [SerializeField] private float suavizadorDeMovimeinto;
    private Vector3 velociad = Vector3.zero;
    private bool mirandoDerecha = true;

    

    [Header("Salto")]

    [SerializeField] private float fuerzaDeSalto;
    [SerializeField] private LayerMask queEsSuelo;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private Vector3 dimensionesCaja;
    [SerializeField] private bool enSuelo;
    private bool salto = false;

    [Header("Rebote")]
    [SerializeField] private float velocidadRebote;

    [Header("SaltoPared")]
    [SerializeField] private Transform controladorPared;
    [SerializeField] private Vector3 dimensionesCajaPared;
    private bool enPared;
    private bool deslizando;
    [SerializeField] private float velocidadDeslizar;


    [Header("animacion")]

    private Animator animator;



    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();  
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        movimientoHorizontal = inputX * velocidadDeMovimiento;

        animator.SetFloat("Horizontal", Mathf.Abs (movimientoHorizontal));

        animator.SetFloat("VelocidadY", rb2D.velocity.y);

        animator.SetBool("Deslizando", deslizando);

        if(Input.GetButtonDown("Jump"))
        {
            salto = true;
            
        }

        if(!enSuelo && enPared && inputX != 0)
        {
            deslizando = true;
        }
        else
        {
            deslizando = false;
        }

        
    }


    private void FixedUpdate()
    {
        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, queEsSuelo);

        animator.SetBool("enSuelo", enSuelo);

        enPared = Physics2D.OverlapBox(controladorPared.position, dimensionesCajaPared, 0f, queEsSuelo);
        Mover(movimientoHorizontal *Time.deltaTime, salto);

        salto = false;

        if(deslizando)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, Mathf.Clamp(rb2D.velocity.y, -velocidadDeslizar, float.MaxValue));
        }
    }

    private void Mover(float mover, bool saltar)
    {
        Vector3 velocidadObjetivo = new Vector2(mover, rb2D.velocity.y);
        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, velocidadObjetivo, ref velociad, suavizadorDeMovimeinto);

        if(mover > 0 && !mirandoDerecha)
        {
            Girar();
        }

        else if(mover < 0 && mirandoDerecha)
        {
            Girar();
        }

        if(enSuelo && saltar)
        {
            enSuelo= false;
            rb2D.AddForce(new Vector2(0f, fuerzaDeSalto));
        }
    }

    public void Rebote()
    {
        rb2D.velocity = new Vector2(rb2D.velocity.x, velocidadRebote);
    }

    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(controladorSuelo.position, dimensionesCaja);
        Gizmos.DrawWireCube(controladorPared.position, dimensionesCajaPared);
    }
}
