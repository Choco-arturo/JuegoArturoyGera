using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyDetectionScript : MonoBehaviour
{
    public string enemyTag = "Enemy";
    public string nextSceneName;

    private void Update()
    {
        // Buscar todos los objetos con el tag "Enemy"
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        // Si no hay enemigos en la escena, cambiar a la siguiente escena
        if (enemies.Length == 0)
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
