using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float distanciaDetectar; // La distancia a la que el enemigo detectará al jugador.
    public float distanciaAtaque; // La distancia a la que el enemigo realizará un ataque.
    public float radioAtaque; // El radio del área de ataque del enemigo.
    public float danoAtaque; // El daño que el enemigo infligirá al jugador.
    public float velocidadMovimiento; // La velocidad de movimiento del enemigo.
    public float vida; // La vida del enemigo.

    public Transform jugador; // Referencia al objeto del jugador.
    public Transform controladorAtaque; // Referencia al objeto que controla el rango de ataque del enemigo.

    private Animator animator; // Referencia al componente Animator del enemigo.
    public Rigidbody2D rb2D; // Referencia al componente Rigidbody2D del enemigo.
    private bool mirandoDerecha = true; // Variable que indica si el enemigo está mirando hacia la derecha.

    private enum EnemyState
    {
        Idle, // Estado de inactividad.
        Moving, // Estado de movimiento.
        Attacking, // Estado de ataque.
        Dead // Estado de muerte.
    }
    private EnemyState currentState; // El estado actual del enemigo.

    private void Start()
    {
        animator = GetComponent<Animator>(); // Obtiene el componente Animator del enemigo.
        rb2D = GetComponent<Rigidbody2D>(); // Obtiene el componente Rigidbody2D del enemigo.
        currentState = EnemyState.Idle; // Establece el estado inicial del enemigo como inactivo.
    }

    private void Update()
    {
        if (currentState == EnemyState.Dead)
        {
            return; // Si el estado del enemigo es "Dead" (muerto), se sale del método sin hacer nada más.
        }

        float distanciaJugador = Vector2.Distance(transform.position, jugador.position); // Calcula la distancia entre el enemigo y el jugador.

        if (distanciaJugador <= distanciaDetectar && distanciaJugador > distanciaAtaque)
        {
            currentState = EnemyState.Moving; // Si el jugador está dentro del rango de detección pero fuera del rango de ataque, el estado se establece como "Moving" (moviéndose).
        }
        else if (distanciaJugador <= distanciaAtaque)
        {
            currentState = EnemyState.Attacking; // Si el jugador está dentro del rango de ataque, el estado se establece como "Attacking" (atacando).
        }
        else
        {
            currentState = EnemyState.Idle; // De lo contrario, el estado se establece como "Idle" (inactivo).
        }

        UpdateAnimationState(); // Actualiza el estado de las animaciones del enemigo.
    }

    private void FixedUpdate()
    {
        if (currentState == EnemyState.Moving)
        {
            MoveTowardsPlayer(); // Si el estado del enemigo es "Moving" (moviéndose), se mueve hacia el jugador.
        }
    }

    private void MoveTowardsPlayer()
    {
        Vector2 direccionMovimiento = (jugador.position - transform.position).normalized;
        rb2D.AddForce(direccionMovimiento * velocidadMovimiento);

        float direccion = Mathf.Sign(jugador.position.x - transform.position.x);

        if (direccion > 0 && !mirandoDerecha)
        {
            Flip();
        }
        else if (direccion < 0 && mirandoDerecha)
        {
            Flip();
        }
    }

    private void Flip()
    {
        mirandoDerecha = !mirandoDerecha;
        transform.Rotate(0f, 180f, 0f);
    }

    private void Attack()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorAtaque.position, radioAtaque);
        foreach (Collider2D colision in objetos)
        {
            if (colision.CompareTag("Player"))
            {
                colision.GetComponent<CombateJugador>().TomarDano(danoAtaque);
            }
        }
    }

    public void TakeDamage(float damage)
    {
        vida -= damage;

        if (vida <= 0)
        {
            currentState = EnemyState.Dead;
            animator.SetTrigger("Muerte");
            rb2D.velocity = Vector2.zero;
            GetComponent<Collider2D>().enabled = false;
            // Realizar cualquier otra lógica de muerte del enemigo aquí
        }
    }

    private void UpdateAnimationState()
    {
        animator.SetBool("IsMoving", currentState == EnemyState.Moving);
        animator.SetBool("IsAttacking", currentState == EnemyState.Attacking);
        animator.SetBool("IsDead", currentState == EnemyState.Dead);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorAtaque.position, radioAtaque);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distanciaDetectar);
    }
}
