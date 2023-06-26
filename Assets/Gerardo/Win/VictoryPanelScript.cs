using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VictoryPanelScript : MonoBehaviour
{
    public GameObject victoryPanel;
    public Button menuButton;
    public Button nextLevelButton;

    private int currentSceneIndex;
    private bool sceneChanged = false;

    void Start()
    {
        victoryPanel.SetActive(false);
        menuButton.onClick.AddListener(GoToMenu);
        nextLevelButton.onClick.AddListener(LoadNextLevel);

        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void ShowVictoryPanel()
    {
        victoryPanel.SetActive(true);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LoadNextLevel()
    {
        if (!sceneChanged)
        {
            int nextSceneIndex = currentSceneIndex + 1;

            if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(nextSceneIndex);
                sceneChanged = true; // Marca que el cambio de escena ocurrió
            }
            else
            {
                // Si ya estás en la última escena, puedes hacer algo como reiniciar el juego o volver al menú principal
                SceneManager.LoadScene("Menu");
                sceneChanged = true; // Marca que el cambio de escena ocurrió
            }
        }
    }
}