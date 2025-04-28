using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    public GameObject basicEnemyPrefab;
    public GameObject shootingEnemyPrefab;
    public GameObject crawlingEnemyPrefab;

    [Header("Spawn Settings")]
    public Transform player;
    public float spawnRadius = 30f;
    public int basicEnemyCount = 5;
    public int shootingEnemyCount = 2;
    public int crawlingEnemyCount = 1;
    public float minDistanceFromPlayer = 10f;
    public LayerMask enemyLayerMask;
    public float minDistanceBetweenEnemies = 5f;
    public int maxAttempts = 30;

    private List<Vector3> spawnedPositions = new List<Vector3>();

    void Start()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        SpawnEnemyType(basicEnemyPrefab, basicEnemyCount);
        SpawnEnemyType(shootingEnemyPrefab, shootingEnemyCount);
        SpawnEnemyType(crawlingEnemyPrefab, crawlingEnemyCount);
    }

    void SpawnEnemyType(GameObject enemyPrefab, int count)
    {
        if (enemyPrefab == null) return;

        for (int i = 0; i < count; i++)
        {
            bool spawned = false;

            for (int attempt = 0; attempt < maxAttempts; attempt++)
            {
                Vector2 randomCircle = Random.insideUnitCircle * spawnRadius;
                Vector3 spawnPosition = player.position + new Vector3(randomCircle.x, 0f, randomCircle.y);

                // Make sure not too close to player
                float playerDistance = Vector3.Distance(player.position, spawnPosition);
                if (playerDistance < minDistanceFromPlayer)
                    continue;

                // Make sure not too close to other enemies
                bool tooClose = false;
                foreach (var pos in spawnedPositions)
                {
                    if (Vector3.Distance(pos, spawnPosition) < minDistanceBetweenEnemies)
                    {
                        tooClose = true;
                        break;
                    }
                }

                if (tooClose)
                    continue;

                // Instantiate enemy
                GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                enemy.transform.rotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);

                spawnedPositions.Add(spawnPosition);
                spawned = true;
                break;
            }

            if (!spawned)
            {
                Debug.LogWarning($"Failed to spawn {enemyPrefab.name} after {maxAttempts} attempts.");
            }
        }
    }
}
