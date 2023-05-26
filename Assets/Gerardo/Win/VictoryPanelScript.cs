using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VictoryPanelScript : MonoBehaviour
{
    public GameObject victoryPanel;
    public Button menuButton;

    void Start()
    {
        victoryPanel.SetActive(false);
        menuButton.onClick.AddListener(GoToMenu);
    }

    public void ShowVictoryPanel()
    {
        victoryPanel.SetActive(true);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}