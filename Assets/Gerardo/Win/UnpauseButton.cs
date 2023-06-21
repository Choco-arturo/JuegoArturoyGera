using UnityEngine;

public class UnpauseButton : MonoBehaviour
{
    public GameObject missingRecolectablesPanel;

    public void UnpauseGame()
    {
        Time.timeScale = 1f; // Despausar el juego estableciendo el timeScale a 1
        missingRecolectablesPanel.SetActive(false);
    }
}
