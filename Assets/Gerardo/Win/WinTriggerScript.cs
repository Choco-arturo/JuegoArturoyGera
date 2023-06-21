using UnityEngine;

public class WinTriggerScript : MonoBehaviour
{
    public GameObject winPanel;
    public GameObject missingRecolectablesPanel;
    public RecolectableCounter recolectableCounter;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (recolectableCounter.GetRecolectables() >= 7)
            {
                Destroy(other.gameObject);
                winPanel.SetActive(true);
            }
            else
            {
                missingRecolectablesPanel.SetActive(true);
            }
        }
    }
}
