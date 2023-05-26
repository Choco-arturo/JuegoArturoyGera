using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDano
{
    public EnemyData enemyData;
    private Animator animator;
    public Transform jugador;
    public bool mirandoDerecha = true;
    [SerializeField] private Transform rangoAtaqueObjeto;

    private void Start()
    {
        animator = GetComponent<Animator>();
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        float distanciaJugador = Vector2.Distance(transform.position, jugador.position);
        animator.SetFloat("distanciaJugador", distanciaJugador);
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

    public void MirarJugador()
    {
        if ((jugador.position.x > transform.position.x && !mirandoDerecha) || (jugador.position.x < transform.position.x && mirandoDerecha))
        {
            mirandoDerecha = !mirandoDerecha;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        }
    }

    public void Ataque()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(rangoAtaqueObjeto.position, enemyData.radioAtaque);
        foreach (Collider2D colision in objetos)
        {
            colision.GetComponent<CombateJugador>().TomarDano(enemyData.danoAtaque);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(rangoAtaqueObjeto.position, enemyData.radioAtaque);
    }
}
