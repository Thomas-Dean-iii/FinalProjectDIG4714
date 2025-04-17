using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkProps : MonoBehaviour
{
    [Header("Prop Settings")]
    public GameObject[] frequentProps;
    public GameObject[] mediumProps;
    public GameObject[] rareProps;

    public int frequentCount = 1; // Grass frequency
    public int mediumCount = 5;   // Tree and rock frequency
    public int rareCount = 10;    // Prebuilt frequency

    [Header("Chunk Settings")]
    public Vector2 chunkSize = new Vector2(50f, 50f);

    void Start()
    {
        SpawnProps(frequentProps, frequentCount);
        SpawnProps(mediumProps, mediumCount);
        SpawnProps(rareProps, rareCount);
    }

    void SpawnProps(GameObject[] propArray, int count)
    {
        for (int i = 0; i < count; i++)
        {
            if (propArray.Length == 0) continue;

            Vector3 randomPosition = new Vector3(
                Random.Range(0f, chunkSize.x),
                0f,
                Random.Range(0f, chunkSize.y)
            );

            GameObject propToSpawn = propArray[Random.Range(0, propArray.Length)];
            GameObject prop = Instantiate(
                propToSpawn,
                transform.position + randomPosition,
                Quaternion.identity,
                this.transform
            );

            // Height correction to avoid clipping with ground
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
