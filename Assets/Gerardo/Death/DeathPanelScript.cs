using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathPanelScript : MonoBehaviour
{
    public GameObject deathPanel;
    public Button restartButton;
    public CombateJugador combateJugador;
    public AudioClip gameOverMusic;
    private AudioSource audioSource;

    void Start()
    {
        deathPanel.SetActive(false);
        restartButton.onClick.AddListener(RestartLevel);
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (combateJugador.vida <= 0)
        {
            ShowDeathPanel();
            
        }
    }

    public void ShowDeathPanel()
    {
        deathPanel.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PlayGameOverMusic()
    {
        audioSource.clip = gameOverMusic;
        audioSource.Play();
    }
}
