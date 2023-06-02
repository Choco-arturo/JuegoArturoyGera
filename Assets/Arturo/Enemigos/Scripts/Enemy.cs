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
        // Dibujar el radio de detección en el editor
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

        // Dibujar el radio de ataque en el editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }

    private void Update()
    {
        // Comprobar si el jugador está dentro del radio de detección
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer <= detectionRadius)
        {
            playerDetected = true;
        }
        else
        {
            playerDetected = false;
        }

        // Actualizar los parámetros del Animator
        animator.SetBool("Moving", playerDetected);
        animator.SetBool("Attacking", distanceToPlayer <= attackRadius);

        // Si el jugador está dentro del radio de ataque, atacar
        if (distanceToPlayer <= attackDistance)
        {
            Attack();
        }
        else if (playerDetected)
        {
            // Si el jugador está detectado pero fuera del radio de ataque, moverse hacia él
            MoveTowardsPlayer();
        }
        else
        {
            // Si el jugador no está detectado, detener la animación de movimiento
            animator.SetBool("Moving", false);
        }
    }

    public bool EstaEnMovimiento()
    {
        // Verificar si el enemigo se está moviendo en el eje X
        return Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > 0.1f;
    }

    private void MoveTowardsPlayer()
    {
        // Calcular la dirección hacia el jugador
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
        // Realizar la lógica de ataque aquí
        Debug.Log("¡Ataque!");
    }
}
