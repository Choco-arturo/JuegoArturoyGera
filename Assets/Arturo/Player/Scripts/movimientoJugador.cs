using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class movimientoJugador : MonoBehaviour
{
    private Rigidbody2D rb2D;

    [Header("Movimiento")]

    private float inputX;

    private float movimientoHorizontal = 0f;

    [SerializeField] private float velocidadDeMovimiento;
    [Range (0, 0.3f)] [SerializeField] private float suavizadorDeMovimeinto;
    public Vector2 velociad = Vector2.zero;
    private bool mirandoDerecha = true;

    

    [Header("Salto")]

    [SerializeField] private float fuerzaDeSalto;
    [SerializeField] private LayerMask queEsSuelo;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private Vector2 dimensionesCaja;
    [SerializeField] private bool enSuelo;
    private bool salto = false;

    [Header("Rebote")]
    [SerializeField] private float velocidadRebote;

    [Header("SaltoPared")]
    [SerializeField] private Transform controladorPared;
    [SerializeField] private Vector2 dimensionesCajaPared;
    private bool enPared;
    private bool deslizando;
    [SerializeField] private float velocidadDeslizar;


    [Header("animacion")]

    private Animator animator;

    public PlayerInput _playerInput;

    public AudioClip[] footstepSounds;
    public float stepInterval = 0.5f;
    public AudioSource audioSource;
    private float stepTimer;
    private bool isMoving;

    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        rb2D = GetComponent<Rigidbody2D>();  
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        stepTimer = stepInterval;

    }

    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        movimientoHorizontal = inputX * velocidadDeMovimiento;

        animator.SetFloat("Horizontal", Mathf.Abs(movimientoHorizontal));

        animator.SetFloat("VelocidadY", rb2D.velocity.y);

        animator.SetBool("Deslizando", deslizando);



        if (_playerInput.actions["Jump"].WasPressedThisFrame())
        {
            salto = true;

        }

        if (!enSuelo && enPared && inputX != 0)
        {
            deslizando = true;
        }
        else
        {
            deslizando = false;
        }

        stepTimer -= Time.deltaTime;

        if (stepTimer <= 0f)
        {
            PlayFootstepSound();
            stepTimer = stepInterval;
        }
        else 
        {
            audioSource.Stop();
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
        Vector2 velocidadObjetivo = new Vector2(mover, rb2D.velocity.y);
        rb2D.velocity = Vector2.SmoothDamp(rb2D.velocity, velocidadObjetivo, ref velociad, suavizadorDeMovimeinto);

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

        if (mover != 0f)
        {
            PlayFootstepSound();
        }
    }

    public void Rebote()
    {
        rb2D.velocity = new Vector2(rb2D.velocity.x, velocidadRebote);
    }

    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector2 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(controladorSuelo.position, dimensionesCaja);
        Gizmos.DrawWireCube(controladorPared.position, dimensionesCajaPared);
    }

    private void PlayFootstepSound()
    {
        if (footstepSounds.Length > 0)
        {
            int randomIndex = Random.Range(0, footstepSounds.Length);
            audioSource.clip = footstepSounds[randomIndex];
            audioSource.Play();
        }
    }
}
