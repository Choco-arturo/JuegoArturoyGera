using UnityEngine;

public class WinTriggerScript : MonoBehaviour
{
    public GameObject winPanel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            winPanel.SetActive(true);
        }
    }
}
