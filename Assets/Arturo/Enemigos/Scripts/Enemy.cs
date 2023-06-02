using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float attackRadius = 3f;
    public float detectionRadius = 10f;
    public float movementSpeed = 5f;
    public float attackDistance = 1.5f;

    private bool playerDetected = false;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnDrawGizmosSelected()
    {
        // Dibujar el radio de detecci�n en el editor
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

        // Dibujar el radio de ataque en el editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }

    private void Update()
    {
        // Comprobar si el jugador est� dentro del radio de detecci�n
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer <= detectionRadius)
        {
            playerDetected = true;
        }
        else
        {
            playerDetected = false;
        }

        // Actualizar los par�metros del Animator
        animator.SetBool("Moving", playerDetected);
        animator.SetBool("Attacking", distanceToPlayer <= attackRadius);

        // Si el jugador est� dentro del radio de ataque, atacar
        if (distanceToPlayer <= attackDistance)
        {
            Attack();
        }
        else if (playerDetected)
        {
            // Si el jugador est� detectado pero fuera del radio de ataque, moverse hacia �l
            MoveTowardsPlayer();
        }
        else
        {
            // Si el jugador no est� detectado, detener la animaci�n de movimiento
            animator.SetBool("Moving", false);
        }
    }

    public bool EstaEnMovimiento()
    {
        // Verificar si el enemigo se est� moviendo en el eje X
        return Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > 0.1f;
    }

    private void MoveTowardsPlayer()
    {
        // Calcular la direcci�n hacia el jugador
        Vector2 direction = (player.position - transform.position).normalized;
        Debug.Log("Direction: " + direction);

        // Moverse hacia el jugador
        GetComponent<Rigidbody2D>().velocity = direction * movementSpeed;

        // Voltear al enemigo hacia el jugador
        if (direction.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (direction.x < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void Attack()
    {
        // Realizar la l�gica de ataque aqu�
        Debug.Log("�Ataque!");
    }
}
