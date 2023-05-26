using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDano
{
    public EnemyData enemyData;
    private Animator animator;
    public Transform jugador;
    public bool mirandoDerecha = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        float distanciaJugador = Vector2.Distance(transform.position, jugador.position);
        animator.SetFloat("distanciaJugador", distanciaJugador);

        //if (distanciaJugador <= enemyData.distanciaAtaque)
       // {
            //MoverHaciaJugador();
        //}
    }

    private void MoverHaciaJugador()
    {
        float direccion = Mathf.Sign(jugador.position.x - transform.position.x);

        if (direccion > 0 && !mirandoDerecha)
        {
            Girar();
        }
        else if (direccion < 0 && mirandoDerecha)
        {
            Girar();
        }

        //transform.position = Vector2.MoveTowards(transform.position, jugador.position, enemyData.velocidadMovimiento * Time.deltaTime);
    }

    public void TomarDano(float dano)
    {
        enemyData.vida -= dano;

        if (enemyData.vida <= 0)
        {
            animator.SetTrigger("Muerte");
        }
    }

    public void Muerte()
    {
        Destroy(gameObject);
    }

    public void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        transform.Rotate(0f, 180f, 0f);
    }

    public void Ataque()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(transform.position, enemyData.radioAtaque);
        foreach (Collider2D colision in objetos)
        {
            colision.GetComponent<CombateJugador>().TomarDano(enemyData.danoAtaque);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, enemyData.radioAtaque);
    }
}
