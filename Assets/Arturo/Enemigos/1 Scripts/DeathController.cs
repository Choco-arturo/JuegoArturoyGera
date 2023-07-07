using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour
{
    public void DestroyAfterDeathAnimation()
    {
        EnemyBasic enemy = GetComponent<EnemyBasic>();
        if (enemy != null)
        {
            enemy.DestroyObject();
        }
    }
}
