using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateJugador : MonoBehaviour
{
    [SerializeField] public int vida;
    public AudioSource audioSource;
    public AudioClip loseLifeSound;
    public AudioClip gainLifeSound;
    public AudioClip lastLifeSound;
    public AudioSource musicAudioSource;

    private Animator animator;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    public void TomarDano(int dano)
    {
        CheckLife();
        vida -= dano;

        if (vida <= 0)
        {
            // Reproducir animación de muerte
            animator.SetTrigger("dead");
        }
        else
        {
            if (loseLifeSound != null)
            {
                audioSource.PlayOneShot(loseLifeSound);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            CheckLife();
            vida = 0;

            // Reproducir animación de muerte
            animator.SetTrigger("dead");
        }
    }

    public GameObject[] vidas;

    void CheckLife()
    {
        int corazonesActivos = vida; // Obtener la cantidad de corazones activos

        for (int i = 0; i < vidas.Length; i++)
        {
            if (i < corazonesActivos)
            {
                vidas[i].SetActive(true);
            }
            else
            {
                vidas[i].SetActive(false);
            }
        }

        if (vida <= 2 && !audioSource.isPlaying)
        {
            audioSource.clip = lastLifeSound;
            audioSource.loop = true;
            audioSource.Play();
        }
        else
        {
            audioSource.clip = lastLifeSound;
            audioSource.loop = false;
            audioSource.Stop();
        }
    }

    public void PlayerHealthed()
    {
        vida += 1;

        if (vida > vidas.Length)
        {
            vida = vidas.Length;
        }

        CheckLife();

        if (gainLifeSound != null)
        {
            audioSource.PlayOneShot(gainLifeSound);
        }
    }
}
