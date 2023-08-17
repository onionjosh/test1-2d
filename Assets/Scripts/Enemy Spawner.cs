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
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPosition = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), Camera.main.nearClipPlane));

        // Calculate direction from the player.
        Vector3 directionFromPlayer = (spawnPosition - playerTransform.position).normalized;

        // Adjust the spawn position to be at least 'spawnDistanceFromPlayer' units away from the player.
        spawnPosition = playerTransform.position + directionFromPlayer * spawnDistanceFromPlayer;

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

    // Helper method to count the number of active enemies in the scene.
    private int ActiveEnemyCount()
    {
        return GameObject.FindGameObjectsWithTag("Enemy").Length;  // Assuming your enemy prefab has the tag "Enemy".
    }
}
