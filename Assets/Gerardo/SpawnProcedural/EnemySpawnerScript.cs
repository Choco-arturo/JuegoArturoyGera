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
        Vector2 spawnPosition = transform.position;

        for (int i = 0; i < numberOfEnemies; i++)
        {
            Vector2 randomOffset = Random.insideUnitCircle * spawnRadius;
            Vector2 enemyPosition = spawnPosition + new Vector2(randomOffset.x, randomOffset.y);
            Instantiate(enemyPrefab, enemyPosition, Quaternion.identity);
            //Vector2 randomPosition = Random.insideUnitCircle * spawnRadius;
            //Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
        }

    }
}
