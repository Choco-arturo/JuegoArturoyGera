using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int numberOfEnemies = 5;
    public float spawnRadius = 10f;

    void Start()
    {
        SpawnEnemies();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }

    void SpawnEnemies()
    {
        Vector3 spawnPosition = transform.position; // Utiliza la posición del objeto "EnemySpawner" como referencia de generación

        for (int i = 0; i < numberOfEnemies; i++)
        {
            Vector2 randomOffset = Random.insideUnitCircle * spawnRadius;
            Vector3 enemyPosition = spawnPosition + new Vector3(randomOffset.x, randomOffset.y, 0);
            Instantiate(enemyPrefab, enemyPosition, Quaternion.identity);
        }
    }
}
