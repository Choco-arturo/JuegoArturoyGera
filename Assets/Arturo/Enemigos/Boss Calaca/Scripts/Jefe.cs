using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jefe : MonoBehaviour, IDano
{
    private Animator animator;
    public Rigidbody2D rb2D;
    public Transform jugador;
    public bool mirandoDerecha = true;

    [Header("Vida")]
    [SerializeField] private int vida;
    [SerializeField] private BarraDevida barraDeVida;

    [Header("Ataque")]
    [SerializeField] private Transform controladorAtaque;
    [SerializeField] private float radioAtaque;
    [SerializeField] private int danoAtaque;



    private void Start()
    {
        animator = GetComponent<Animator>();
        rb2D= GetComponent<Rigidbody2D>();
        barraDeVida.InicializarBarraDeVida(vida);
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        float distanciaJugador = Vector2.Distance(transform.position, jugador.position);
        animator.SetFloat("distanciaJugador", distanciaJugador);

    }

    public void TomarDano(int dano)
    {
        vida -= dano;
        barraDeVida.CambiarVidaActual(vida);

        if(vida <= 0)
        {
            animator.SetTrigger("Muerte");
        }
    }

    public void Muerte()
    {
        Destroy(gameObject);
    }

    public void MirarJugador()
    {
        if((jugador.position.x > transform.position.x && !mirandoDerecha) || (jugador.position.x < transform.position.x && mirandoDerecha))
        {
            mirandoDerecha = !mirandoDerecha;
            transform.eulerAngles = new Vector2(0, transform.eulerAngles.y + 180);
        }
    }    

    public void Ataque()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorAtaque.position, radioAtaque);
        foreach(Collider2D colision in objetos)
        {
            colision.GetComponent<CombateJugador>().TomarDano(danoAtaque);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorAtaque.position, radioAtaque);
    }
}
