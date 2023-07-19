using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathPanelScript : MonoBehaviour
{
    public GameObject deathPanel;
    public Button restartButton;
    public Button menuButton;
    public CombateJugador combateJugador;
    public AudioClip gameOverMusic;
    private AudioSource audioSource;
    private float deathDelay = 2f; // Tiempo de retraso para mostrar el panel de muerte (en segundos)

    void Start()
    {
        deathPanel.SetActive(false);
        restartButton.onClick.AddListener(RestartLevel);
        menuButton.onClick.AddListener(ReturnToMenu);
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (combateJugador.vida <= 0)
        {
            // Invocar el método para mostrar el panel de muerte después del retraso
            Invoke("ShowDeathPanel", deathDelay);
        }
    }

    public void ShowDeathPanel()
    {
        PlayGameOverMusic(); // Reproducir música de Game Over
        deathPanel.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void PlayGameOverMusic()
    {
        audioSource.clip = gameOverMusic;
        audioSource.Play();
    }
}
