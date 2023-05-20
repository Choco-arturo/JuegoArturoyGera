using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{

    public GameObject[] vidas;
    public int life;

    void Start()
    {
        life = vidas.Length;
    }

    void CheckLife()
    {
        if (life < 1)
        {
            //Destroy(baterias[0].gameObject);
            vidas[0].SetActive(false);
            PlayerDead();
        }
        else if (life < 2)
        {
            //Destroy(baterias[1].gameObject);
            vidas[1].SetActive(false);
            vidas[0].SetActive(true);
        }
        else if (life < 3)
        {
            //Destroy(baterias[2].gameObject);
            vidas[2].SetActive(false);
            vidas[1].SetActive(true);
        }
        else if (life == 3)
        {
            vidas[2].SetActive(true);
            vidas[1].SetActive(true);
        }
    }

    public void PlayerDamaged()
    {
        life--;
        CheckLife();
        Debug.Log(life);
    }
    public void PlayerHealthed()
    {
        life++;

        if (life >= vidas.Length)
        {
            life = vidas.Length;
        }

        CheckLife();
    }

    public void PlayerDead()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

