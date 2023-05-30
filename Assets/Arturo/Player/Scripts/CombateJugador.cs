using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateJugador : MonoBehaviour
{
    [SerializeField] public float vida;
    public void TomarDano(float dano)
    {
        vida -= dano;

        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            vida = vida - 150f;
            Destroy(gameObject);
        }
    }

}
