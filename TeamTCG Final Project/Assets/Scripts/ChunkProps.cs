using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkProps : MonoBehaviour
{
    [Header("Prop Settings")]
    public GameObject[] frequentProps;
    public GameObject[] mediumProps;
    public GameObject[] rareProps;

    public int frequentCount = 500; // Grass frequency
    public int mediumCount = 10;   // Tree and rock frequency
    public int rareCount = 5;    // Prebuilt frequency

    [Header("Chunk Settings")]
    public Vector2 chunkSize = new Vector2(50f, 50f);

    [Header("Spawn Settings")]
    public float minDistanceBetweenProps = 3f; // Minimum distance between medium/rare props
    public int maxPlacementAttempts = 10; // Max attempts to find a valid spawn point

    private List<Vector3> occupiedPositions = new List<Vector3>();

    void Start()
    {
        SpawnProps(frequentProps, frequentCount, false); // frequent props: no collision check
        SpawnProps(mediumProps, mediumCount, true);      // medium props: collision check
        SpawnProps(rareProps, rareCount, true);          // rare props: collision check
    }

    void SpawnProps(GameObject[] propArray, int count, bool avoidOverlap)
    {
        for (int i = 0; i < count; i++)
        {
            if (propArray.Length == 0) continue;

            Vector3 spawnPosition = Vector3.zero;
            bool foundValidPosition = false;

            for (int attempt = 0; attempt < maxPlacementAttempts; attempt++)
            {
                Vector3 randomPosition = new Vector3(
                    Random.Range(0f, chunkSize.x),
                    0f,
                    Random.Range(0f, chunkSize.y)
                ) + transform.position;

                if (avoidOverlap)
                {
                    bool tooClose = false;
                    foreach (var pos in occupiedPositions)
                    {
                        if (Vector3.Distance(randomPosition, pos) < minDistanceBetweenProps)
                        {
                            tooClose = true;
                            break;
                        }
                    }

                    if (tooClose)
                        continue; // Try another position
                }

                spawnPosition = randomPosition;
                foundValidPosition = true;
                break; // Found a good spot
            }

            if (foundValidPosition)
            {
                GameObject propToSpawn = propArray[Random.Range(0, propArray.Length)];
                GameObject prop = Instantiate(
                    propToSpawn,
                    spawnPosition,
                    Quaternion.identity,
                    this.transform
                );

                if (avoidOverlap)
                {
                    occupiedPositions.Add(spawnPosition);
                }

                // Height correction
                Renderer[] renderers = prop.GetComponentsInChildren<Renderer>();
                if (renderers.Length > 0)
                {
                    Bounds combinedBounds = renderers[0].bounds;
                    for (int r = 1; r < renderers.Length; r++)
                    {
                        combinedBounds.Encapsulate(renderers[r].bounds);
                    }

                    float yOffset = combinedBounds.min.y - prop.transform.position.y;
                    prop.transform.position -= new Vector3(0f, yOffset, 0f);
                }
            }
        }
    }
}
