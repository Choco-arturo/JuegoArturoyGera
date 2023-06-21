using UnityEngine;

public class Recolectable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            RecolectableCounter recolectableCounter = FindObjectOfType<RecolectableCounter>();
            if (recolectableCounter != null)
            {
                recolectableCounter.CollectRecolectable();
            }
            Destroy(gameObject);
        }
    }
}