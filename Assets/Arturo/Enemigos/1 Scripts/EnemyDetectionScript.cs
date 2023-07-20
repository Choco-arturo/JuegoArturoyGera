using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyDetectionScript : MonoBehaviour
{
    public string enemyTag = "Enemy";
    public string nextSceneName;
    public float delayBeforeNextScene = 2f; // Tiempo de retraso en segundos antes de cambiar a la siguiente escena

    private void Update()
    {
        // Buscar todos los objetos con el tag "Enemy"
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        // Si no hay enemigos en la escena, llamar al método para cambiar a la siguiente escena después del retraso
        if (enemies.Length == 0)
        {
            Invoke("LoadNextScene", delayBeforeNextScene);
        }
    }

    // Método para cargar la siguiente escena
    private void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}