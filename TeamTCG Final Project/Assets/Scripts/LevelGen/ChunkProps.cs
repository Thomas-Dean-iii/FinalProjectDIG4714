using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkProps : MonoBehaviour
{
    [Header("Prop Settings")] // Prop list and how frequently they spawn
    public GameObject[] frequentProps;
    public GameObject[] mediumProps;
    public GameObject[] rareProps;

    public int frequentCount = 500;
    public int mediumCount = 10;
    public int rareCount = 5;

    [Header("Chunk Settings")] // Size of the chunk area
    public Vector2 chunkSize = new Vector2(50f, 50f);

    [Header("Spawn Settings")] // Settings to reduce prop overlap
    public float minDistanceBetweenProps = 3f;
    public int maxPlacementAttempts = 30;
    public int maxPhysicsOverlapRetries = 3;
    public LayerMask propLayerMask;

    private List<Vector3> occupiedPositions = new List<Vector3>();

    void Start()
    {
        SpawnProps(frequentProps, frequentCount, false); // frequent props: no overlap checks
        SpawnProps(mediumProps, mediumCount, true);      // medium props: needs collision check
        SpawnProps(rareProps, rareCount, true);          // rare props: needs collision check
    }

    // Handles spawning of props with or without overlap avoidance.
    void SpawnProps(GameObject[] propArray, int count, bool avoidOverlap)
    {
        for (int i = 0; i < count; i++)
        {
            if (propArray.Length == 0) continue;

            GameObject propPrefab = propArray[Random.Range(0, propArray.Length)];
            Bounds prefabBounds = GetBounds(propPrefab);

            Vector3 spawnPosition = Vector3.zero;
            bool foundValidPosition = false;

            // Try to find a valid spawn position
            for (int attempt = 0; attempt < maxPlacementAttempts; attempt++)
            {
                Vector3 randomPosition = new Vector3(
                    Random.Range(0f, chunkSize.x),
                    0f,
                    Random.Range(0f, chunkSize.y)
                ) + transform.position;

                Vector3 correctedPosition = randomPosition + prefabBounds.center;

                if (avoidOverlap)
                {
                    // Check distance to existing props
                    bool tooClose = false;
                    foreach (var pos in occupiedPositions)
                    {
                        if (Vector3.Distance(correctedPosition, pos) < minDistanceBetweenProps)
                        {
                            tooClose = true;
                            break;
                        }
                    }

                    if (tooClose)
                        continue;
                }

                spawnPosition = randomPosition;
                foundValidPosition = true;
                break;
            }

            if (foundValidPosition)
            {
                // Spawn the prop
                GameObject prop = Instantiate(
                    propPrefab,
                    spawnPosition,
                    Quaternion.identity,
                    this.transform
                );

                // Correct height so it rests on the ground properly
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

                // Detect collider overlap
                bool overlapFound = false;
                for (int retry = 0; retry < maxPhysicsOverlapRetries; retry++)
                {
                    Collider[] overlaps = Physics.OverlapBox(
                        prop.transform.position + prefabBounds.center,
                        prefabBounds.extents * 0.9f, // Slightly shrink bounds
                        prop.transform.rotation,
                        propLayerMask
                    );

                    bool overlappingAnother = false;
                    foreach (var overlap in overlaps)
                    {
                        if (overlap.gameObject != prop)
                        {
                            overlappingAnother = true;
                            break;
                        }
                    }

                    if (!overlappingAnother)
                    {
                        overlapFound = false;
                        break;
                    }
                    else
                    {
                        overlapFound = true;

                        // Retry spawning at a different position
                        Vector3 retryPosition = new Vector3(
                            Random.Range(0f, chunkSize.x),
                            0f,
                            Random.Range(0f, chunkSize.y)
                        ) + transform.position;
                        prop.transform.position = retryPosition;

                        // Re-adjust height after retry
                        Renderer[] retryRenderers = prop.GetComponentsInChildren<Renderer>();
                        if (retryRenderers.Length > 0)
                        {
                            Bounds retryBounds = retryRenderers[0].bounds;
                            for (int r = 1; r < retryRenderers.Length; r++)
                            {
                                retryBounds.Encapsulate(retryRenderers[r].bounds);
                            }

                            float retryYOffset = retryBounds.min.y - prop.transform.position.y;
                            prop.transform.position -= new Vector3(0f, retryYOffset, 0f);
                        }
                    }
                }

                // If still overlapping after retries, destroy the prop
                if (overlapFound)
                {
                    Destroy(prop);
                    continue;
                }

                // Register this position as occupied if needed
                if (avoidOverlap)
                {
                    occupiedPositions.Add(spawnPosition + prefabBounds.center);
                }
            }
        }
    }

    // Calculates combined bounds of the prop's renderers.
    // Accounts for misplaced pivot points.
    Bounds GetBounds(GameObject prefab)
    {
        Renderer[] renderers = prefab.GetComponentsInChildren<Renderer>();
        if (renderers.Length == 0)
            return new Bounds(Vector3.zero, Vector3.zero);

        Bounds combinedBounds = renderers[0].bounds;
        for (int i = 1; i < renderers.Length; i++)
        {
            combinedBounds.Encapsulate(renderers[i].bounds);
        }

        // Centers the bounds of props
        combinedBounds.center -= prefab.transform.position;

        return combinedBounds;
    }
}


