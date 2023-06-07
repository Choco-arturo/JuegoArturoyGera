using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoSimple : MonoBehaviour, IDano
{

    [Header("Vida")]
    [SerializeField] private int vida;
    public float velocidadMovimiento = 2f;
    public int dano = 20;

    public GameObject triggerCollider;

    private Transform jugador;

    private void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        // Mover el enemigo en dirección al jugador
        Vector2 direccion = (jugador.position - transform.position).normalized;
        transform.Translate(direccion * velocidadMovimiento * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Causar daño al jugador al tocarlo
            CombateJugador combateJugador = collision.GetComponent<CombateJugador>();
            if (combateJugador != null)
            {
                combateJugador.TomarDano(dano);
            }
        }
    }

    public void TomarDano(int dano)
    {
        vida -= dano;
        Destroy(gameObject);
    }
}
