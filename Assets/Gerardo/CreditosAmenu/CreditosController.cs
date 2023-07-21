using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditosController : MonoBehaviour
{
    public float tiempoCreditos = 5f; // Tiempo en segundos para mostrar los cr�ditos

    void Start()
    {
        // Invocar el m�todo para cargar la escena del men� despu�s del tiempo de cr�ditos
        Invoke("CargarMenu", tiempoCreditos);
    }

    private void CargarMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}

