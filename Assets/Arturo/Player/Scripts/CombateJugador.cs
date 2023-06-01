using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateJugador : MonoBehaviour
{
    [SerializeField] public float vida;
    public AudioSource audioSource;
    public AudioClip loseLifeSound;
    public AudioClip gainLifeSound;
    public AudioClip lastLifeSound;
    public AudioSource musicAudioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void TomarDano(float dano)
    {
        CheckLife();
        vida -= dano;

        if (vida <= 0)
        {
            Destroy(gameObject);
            musicAudioSource.GetComponent<AudioSource>().Stop();
        }
        else
        {
            // Reproducir sonido de perder vida
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

            if (!audioSource.isPlaying)
            {
                audioSource.clip = lastLifeSound;
                audioSource.loop = true;
                audioSource.Play();
            }
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

        /*
        // Reproducir sonido de ganar vida
        if (vida == 20 && lastLifeSound != null)
        {
            audioSource.clip = lastLifeSound;
            audioSource.loop = true;
            audioSource.Play();
        }
        else
        {
            // Detener la reproducción en bucle si no es la última vida
            audioSource.Stop();
            audioSource.loop = false;

            // Reproducir sonido de ganar vida
            if (gainLifeSound != null)
            {
                audioSource.PlayOneShot(gainLifeSound);
            }
        }
        */
    }

}
