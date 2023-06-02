using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : StateMachineBehaviour
{
    private Enemy enemy;
    private Transform player;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Comprobar si el enemigo está en movimiento y establecer el parámetro "Moving" en el Animator
        animator.SetBool("Moving", enemy.EstaEnMovimiento());

        // Voltear al enemigo hacia el jugador
        if (player.position.x > enemy.transform.position.x)
        {
            enemy.transform.localScale = new Vector3(1f, 1f, 1f); // Sin voltear
        }
        else if (player.position.x < enemy.transform.position.x)
        {
            enemy.transform.localScale = new Vector3(-1f, 1f, 1f); // Voltear en el eje X
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Comprobar si el enemigo está en movimiento y establecer el parámetro "Moving" en el Animator
        animator.SetBool("Moving", enemy.EstaEnMovimiento());

        // Voltear al enemigo hacia el jugador
        if (player.position.x > enemy.transform.position.x)
        {
            enemy.transform.localScale = new Vector3(1f, 1f, 1f); // Sin voltear
        }
        else if (player.position.x < enemy.transform.position.x)
        {
            enemy.transform.localScale = new Vector3(-1f, 1f, 1f); // Voltear en el eje X
        }
    }
}
