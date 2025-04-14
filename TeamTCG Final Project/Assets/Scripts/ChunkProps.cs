using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkProps : MonoBehaviour
{
    [Header("Prop Settings")]
    public GameObject[] frequentProps;
    public GameObject[] rareProps;

    public int frequentCount = 100; //How frequently things like grass spawn
    public int rareCount = 30; //How frequently things like trees and park benches spawn

    [Header("Chunk Settings")]
    public Vector2 chunkSize = new Vector2(50f, 50f);

    void Start()
    {
        SpawnProps(frequentProps, frequentCount);
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
            Instantiate(
                propToSpawn,
                transform.position + randomPosition,
                Quaternion.identity,
                this.transform
            );
        }
    }
}
