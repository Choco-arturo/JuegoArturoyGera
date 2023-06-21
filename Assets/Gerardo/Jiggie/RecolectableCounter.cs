using UnityEngine;
using TMPro;

public class RecolectableCounter : MonoBehaviour
{
    private int recolectables = 0;
    private TMP_Text textComponent; // Cambio de Text a TMP_Text

    private void Start()
    {
        textComponent = GetComponent<TMP_Text>(); // Cambio de GetComopnent<Text>() a GetComponent<TMP_Text>()
        UpdateUI();
    }

    public void CollectRecolectable()
    {
        recolectables++;
        UpdateUI();
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
