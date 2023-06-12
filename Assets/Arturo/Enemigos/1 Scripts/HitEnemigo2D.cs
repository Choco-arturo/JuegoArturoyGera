using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEnemigo2D : MonoBehaviour
{

    //public int danoAtaque = 10; // Cantidad de daño que el enemigo inflige al jugador

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            CombateJugador player = coll.GetComponent<CombateJugador>();
            if (player != null)
            {
                EnemyBasic enemy = GetComponentInParent<EnemyBasic>();
                if (enemy != null)
                {
                    int danoAtaque = enemy.enemyData.danoAtaque;
                    player.TomarDano(danoAtaque);
                }
            }
        }
    }


}
