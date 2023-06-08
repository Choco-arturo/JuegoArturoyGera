using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VictoryPanelScript : MonoBehaviour
{
    public GameObject victoryPanel;
    public Button menuButton;
    public Button nextLevelButton;

    void Start()
    {
        victoryPanel.SetActive(false);
        menuButton.onClick.AddListener(GoToMenu);
        nextLevelButton.onClick.AddListener(Level2);
    }

    public void ShowVictoryPanel()
    {
        victoryPanel.SetActive(true);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level2");
    }
}