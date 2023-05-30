using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    private Animator animator;
    private Enemy enemyScript;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        enemyScript = GetComponent<Enemy>();
    }

    private void Update()
    {
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (enemyScript.currentState == Enemy.EnemyState.Moving)
        {
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }

        // Actualiza otras variables de animación según sea necesario.
    }
}
