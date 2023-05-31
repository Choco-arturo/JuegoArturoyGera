using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerUI : MonoBehaviour
{

    public GameObject[] vidas;
    public int life;

    void Start()
    {
        life = vidas.Length;
    }

    void CheckLife()
    {
        if (life < 20)
        {
            vidas[0].SetActive(false);
        }
        else if (life < 40)
        {
            vidas[1].SetActive(false);
            vidas[0].SetActive(true);
        }
        else if (life < 60)
        {
            vidas[2].SetActive(false);
            vidas[1].SetActive(true);
        }
        else if (life < 80)
        {
            vidas[3].SetActive(true);
            vidas[2].SetActive(true);
        }
        else if (life < 100)
        {
            vidas[4].SetActive(false);
            vidas[3].SetActive(true);
        }
        else if (life == 100)
        {
            vidas[4].SetActive(true);
            vidas[3].SetActive(true);
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
}
