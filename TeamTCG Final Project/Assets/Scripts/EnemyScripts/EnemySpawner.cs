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
    public float spawnRadius = 30f;
    public int basicEnemyCount = 5;
    public int shootingEnemyCount = 2;
    public int crawlingEnemyCount = 1;
    public float minDistanceFromPlayer = 10f;
    public LayerMask enemyLayerMask;
    public float minDistanceBetweenEnemies = 5f;
    public int maxAttempts = 30;
    public float spawnDelay = 0.1f; // delay between spawns to prevent lag

    private List<Vector3> spawnedPositions = new List<Vector3>();
    private Transform player;
    private Transform enemyContainer;

    void Start()
    {
        StartCoroutine(WaitForPlayerThenSpawn());
    }

    IEnumerator WaitForPlayerThenSpawn()
    {
        while (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
                break;
            }
            yield return null;
        }

        GameObject containerObj = GameObject.Find("EnemyContainer");
        if (containerObj == null)
        {
            containerObj = new GameObject("EnemyContainer");
        }
        enemyContainer = containerObj.transform;

        StartCoroutine(SpawnEnemiesGradually());
    }

    IEnumerator SpawnEnemiesGradually()
    {
        yield return StartCoroutine(SpawnEnemyType(basicEnemyPrefab, basicEnemyCount));
        yield return StartCoroutine(SpawnEnemyType(shootingEnemyPrefab, shootingEnemyCount));
        yield return StartCoroutine(SpawnEnemyType(crawlingEnemyPrefab, crawlingEnemyCount));
    }

    IEnumerator SpawnEnemyType(GameObject enemyPrefab, int count)
    {
        if (enemyPrefab == null) yield break;

        for (int i = 0; i < count; i++)
        {
            bool spawned = false;

            for (int attempt = 0; attempt < maxAttempts; attempt++)
            {
                Vector2 randomCircle = Random.insideUnitCircle * spawnRadius;
                Vector3 spawnPosition = player.position + new Vector3(randomCircle.x, 0f, randomCircle.y);

                if (Vector3.Distance(player.position, spawnPosition) < minDistanceFromPlayer)
                    continue;

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

                GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity, enemyContainer);
                enemy.transform.rotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);

                spawnedPositions.Add(spawnPosition);
                spawned = true;
                break;
            }

            if (!spawned)
            {
                Debug.LogWarning($"Failed to spawn {enemyPrefab.name} after {maxAttempts} attempts.");
            }

            yield return new WaitForSeconds(spawnDelay); // <- Wait a bit before next enemy to reduce lag
        }
    }
}
