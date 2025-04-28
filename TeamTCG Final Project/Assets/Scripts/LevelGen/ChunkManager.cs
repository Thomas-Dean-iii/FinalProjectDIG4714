using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    public GameObject chunkPrefab;
    public Transform player;
    public int chunkRadius = 2; // How many chunks around the player
    public Vector2 chunkSize = new Vector2(50f, 50f);
    public RuntimeNavMeshManager navMeshManager; // Reference to the NavMeshManager

    private Dictionary<Vector2Int, GameObject> activeChunks = new Dictionary<Vector2Int, GameObject>();
    private Vector2Int currentPlayerChunk;

    void Start()
    {
        UpdateChunks(true);
    }

    void Update()
    {
        Vector2Int newPlayerChunk = GetPlayerChunkCoord();
        if (newPlayerChunk != currentPlayerChunk)
        {
            Debug.Log($"Player moved to chunk: {newPlayerChunk}");
            currentPlayerChunk = newPlayerChunk;
            UpdateChunks();
        }
    }

    Vector2Int GetPlayerChunkCoord()
    {
        int x = Mathf.FloorToInt(player.position.x / chunkSize.x);
        int z = Mathf.FloorToInt(player.position.z / chunkSize.y);
        return new Vector2Int(x, z);
    }

    void UpdateChunks(bool forceInit = false)
    {
        HashSet<Vector2Int> newChunks = new HashSet<Vector2Int>();

        for (int x = -chunkRadius; x <= chunkRadius; x++)
        {
            for (int z = -chunkRadius; z <= chunkRadius; z++)
            {
                Vector2Int chunkCoord = currentPlayerChunk + new Vector2Int(x, z);
                newChunks.Add(chunkCoord);

                if (!activeChunks.ContainsKey(chunkCoord))
                {
                    Vector3 position = new Vector3(
                        chunkCoord.x * chunkSize.x,
                        0f,
                        chunkCoord.y * chunkSize.y
                    );
                    GameObject newChunk = Instantiate(chunkPrefab, position, Quaternion.identity);
                    activeChunks.Add(chunkCoord, newChunk);

                    // After a chunk is spawned, rebuild the NavMesh.
                    navMeshManager.RebuildNavMesh();
                }
            }
        }

        // Clean up chunks that are no longer in range
        List<Vector2Int> toRemove = new List<Vector2Int>();
        foreach (var kvp in activeChunks)
        {
            if (!newChunks.Contains(kvp.Key))
            {
                Destroy(kvp.Value);
                toRemove.Add(kvp.Key);
            }
        }

        foreach (var key in toRemove)
        {
            activeChunks.Remove(key);
        }
    }
}
