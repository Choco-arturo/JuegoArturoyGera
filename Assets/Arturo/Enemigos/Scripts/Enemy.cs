using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float distanciaDetectar; // La distancia a la que el enemigo detectar� al jugador.
    public float distanciaAtaque; // La distancia a la que el enemigo realizar� un ataque.
    public float velocidadMovimiento; // La velocidad de movimiento del enemigo.
    public float danoAtaque; // El da�o que el enemigo infligir� al jugador.
    public float vida; // La vida del enemigo.

    public Transform jugador; // Referencia al objeto del jugador.
    public Transform controladorAtaque; // Referencia al objeto que controla el rango de ataque del enemigo.

    
    private bool mirandoDerecha = true; // Variable que indica si el enemigo est� mirando hacia la derecha.

    public enum EnemyState
    {
        Idle, // Estado de inactividad.
        Moving, // Estado de movimiento.
        Attacking, // Estado de ataque.
        Dead // Estado de muerte.
    }
    public EnemyState currentState; // El estado actual del enemigo.

    private void Start()
    {
        
        currentState = EnemyState.Idle; // Establece el estado inicial del enemigo como inactivo.
    }

    private void Update()
    {
        if (currentState == EnemyState.Dead)
        {
            return; // Si el estado del enemigo es "Dead" (muerto), se sale del m�todo sin hacer nada m�s.
        }

        float distanciaJugador = Vector2.Distance(transform.position, jugador.position); // Calcula la distancia entre el enemigo y el jugador.

        if (distanciaJugador <= distanciaDetectar && distanciaJugador > distanciaAtaque)
        {
            currentState = EnemyState.Moving; // Si el jugador est� dentro del rango de detecci�n pero fuera del rango de ataque, el estado se establece como "Moving" (movi�ndose).
        }
        else if (distanciaJugador <= distanciaAtaque)
        {
            currentState = EnemyState.Attacking; // Si el jugador est� dentro del rango de ataque, el estado se establece como "Attacking" (atacando).
        }
        else
        {
            currentState = EnemyState.Idle; // De lo contrario, el estado se establece como "Idle" (inactivo).
        }

        

        if (currentState == EnemyState.Moving)
        {
            MoveTowardsPlayer(); // Si el estado del enemigo es "Moving" (movi�ndose), se mueve hacia el jugador.
        }
        else if (currentState == EnemyState.Attacking)
        {
            Attack(); // Si el estado del enemigo es "Attacking" (atacando), ataca al jugador.
        }
    }

    private void MoveTowardsPlayer()
    {
        Vector2 direccionMovimiento = (jugador.position - transform.position).normalized;
        transform.Translate(direccionMovimiento * velocidadMovimiento * Time.deltaTime);

        float direccion = Mathf.Sign(jugador.position.x - transform.position.x);

        if (direccion > 0 && !mirandoDerecha)
        {
            Flip(); // Voltear al enemigo hacia la derecha si el jugador est� a la derecha y el enemigo no est� mirando en esa direcci�n.
        }
        else if (direccion < 0 && mirandoDerecha)
        {
            Flip(); // Voltear al enemigo hacia la izquierda si el jugador est� a la izquierda y el enemigo no est� mirando en esa direcci�n.
        }
    }

    private void Flip()
    {
        mirandoDerecha = !mirandoDerecha; // Invertir la variable booleana que indica si el enemigo est� mirando hacia la derecha.
        Vector2 escala = transform.localScale;
        escala.x *= -1; // Invertir la escala en el eje X para voltear al enemigo.
        transform.localScale = escala;
    }

    private void UpdateAnimationState()
    {
        // Actualizar las animaciones del enemigo seg�n el estado actual.
    }

    private void Attack()
    {
        // L�gica de ataque del enemigo.
    }

    private void OnDrawGizmosSelected()
    {
        // Dibujar un gizmo para representar la distancia de detecci�n del enemigo.
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distanciaDetectar);
    }
}
