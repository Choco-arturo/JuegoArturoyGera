using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditosController : MonoBehaviour
{
    public float tiempoCreditos = 5f; // Tiempo en segundos para mostrar los créditos

    void Start()
    {
        // Invocar el método para cargar la escena del menú después del tiempo de créditos
        Invoke("CargarMenu", tiempoCreditos);
    }

    private void CargarMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}

