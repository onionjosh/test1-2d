using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform playerTransform;  // Reference to the player's transform.
    public float spawnRate = 1f;  // Number of enemies spawned per second.
    public float spawnDistanceFromPlayer = 5f;  // Minimum distance from the player where enemies will spawn.
    public int maxActiveEnemies = 10;  // Maximum number of active enemies.

    private float nextSpawnTime;

    private void Update()
    {
        if (Time.time >= nextSpawnTime && ActiveEnemyCount() < maxActiveEnemies)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + 1f / spawnRate;
        }

        if (enemyPrefab == null)
        {
            Debug.LogError("Enemy prefab not assigned in the Inspector");
        }
        else
        {
            //Debug.Log("Enemy prefab is assigned");
        }
    }

    private void SpawnEnemy()
    {
        if (enemyPrefab == null)
        {
            Debug.LogError("Enemy prefab is null!");
            return;
        }

        if (playerTransform != null)
        {
            // Generate a random angle
            float randomAngle = Random.Range(0, 360);

            // Create a Vector3 direction based on the angle
            Vector3 directionFromPlayer = new Vector3(Mathf.Sin(randomAngle), Mathf.Cos(randomAngle), 0).normalized;

            // Calculate spawn position to be at least 'spawnDistanceFromPlayer' units away from the player
            Vector3 spawnPosition = playerTransform.position + directionFromPlayer * spawnDistanceFromPlayer;

            // Instantiate the enemy
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        } 
        else 
        {
            Debug.LogError("playerTransform is null!");
        }
    }


    // Helper method to count the number of active enemies in the scene.
    private int ActiveEnemyCount()
    {
        return GameObject.FindGameObjectsWithTag("Enemy").Length;  // Assuming your enemy prefab has the tag "Enemy".
    }
}
