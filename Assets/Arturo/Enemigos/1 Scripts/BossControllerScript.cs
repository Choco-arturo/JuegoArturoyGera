using UnityEngine;

public class BossControllerScript : MonoBehaviour
{
    public GameObject bossPrefab;

    private void Start()
    {
        // Desactivar el jefe final al inicio
        bossPrefab.SetActive(false);
    }

    public void ActivateBoss()
    {
        // Activar el jefe final cuando se llame a este método
        bossPrefab.SetActive(true);
    }
}
