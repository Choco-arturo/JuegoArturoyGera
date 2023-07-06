using UnityEngine;
using TMPro;

public class RecolectableCounter : MonoBehaviour
{
    public AudioSource audioSource;
    public float volume = 1f;

    private int recolectables = 0;
    private TMP_Text textComponent;

    private void Start()
    {
        textComponent = GetComponent<TMP_Text>();
        UpdateUI();
    }

    public void CollectRecolectable()
    {
        recolectables++;
        UpdateUI();

        // Reproducir el sonido del recolectable utilizando el AudioSource
        if (audioSource != null)
        {
            audioSource.PlayOneShot(audioSource.clip, volume);
        }
    }

    public int GetRecolectables()
    {
        return recolectables;
    }

    private void UpdateUI()
    {
        textComponent.text = recolectables.ToString();
    }
}
