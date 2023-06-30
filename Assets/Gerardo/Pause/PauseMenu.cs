using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    public AudioSource audioSource;
    public AudioClip pauseSound;
    public AudioClip unpauseSound;

    private bool isPaused = false;

    private PlayerInput playerInput;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        if (playerInput.actions["Pause"].WasPressedThisFrame())
        {
            if (isPaused)
                Unpause();
            else
                Pause();
        }
    }

    public void Pause()
    {
        if (!isPaused)
        {
            PausePanel.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;

            // Reproducir sonido de pausa
            if (audioSource != null && pauseSound != null)
                audioSource.PlayOneShot(pauseSound);
        }
    }

    public void Unpause()
    {
        if (isPaused)
        {
            PausePanel.SetActive(false);
            Time.timeScale = 1;
            isPaused = false;

            // Reproducir sonido de despausa
            if (audioSource != null && unpauseSound != null)
                audioSource.PlayOneShot(unpauseSound);
        }
    }

    public void ReturnMenu()
    {
        Unpause();
        SceneManager.LoadScene(0);
    }
}
