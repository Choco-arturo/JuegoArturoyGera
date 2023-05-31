using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateJugador : MonoBehaviour
{
    [SerializeField] public float vida;
    public void TomarDano(float dano)
    {
        CheckLife();
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
            CheckLife();
            vida = vida - 150f;
            Destroy(gameObject);
        }
    }

    public GameObject[] vidas;

    void CheckLife()
    {
        if (vida <= 0f)
        {
            vidas[4].SetActive(false);
            vidas[3].SetActive(false);
            vidas[2].SetActive(false);
            vidas[1].SetActive(false);
            vidas[0].SetActive(false);
        }
        else if (vida == 20f)
        {
            vidas[4].SetActive(false);
            vidas[3].SetActive(false);
            vidas[2].SetActive(false);
            vidas[1].SetActive(false);
            vidas[0].SetActive(false);
        }
        else if (vida == 40f)
        {
            vidas[4].SetActive(false);
            vidas[3].SetActive(false);
            vidas[2].SetActive(false);
            vidas[1].SetActive(false);
            vidas[0].SetActive(true);
        }
        else if (vida == 60f)
        {
            vidas[4].SetActive(false);
            vidas[3].SetActive(false);
            vidas[2].SetActive(false);
            vidas[1].SetActive(true);
            vidas[0].SetActive(true);
        }
        else if (vida == 80f)
        {
            vidas[4].SetActive(false);
            vidas[3].SetActive(false);
            vidas[2].SetActive(true);
            vidas[1].SetActive(true);
            vidas[0].SetActive(true);
        }
        else if (vida == 100f)
        {
            vidas[4].SetActive(false);
            vidas[3].SetActive(true);            
            vidas[2].SetActive(true);
            vidas[1].SetActive(true);
            vidas[0].SetActive(true);
        }
    }

}
