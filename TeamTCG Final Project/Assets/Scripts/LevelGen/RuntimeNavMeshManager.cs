using UnityEngine;
using Unity.AI.Navigation;

public class RuntimeNavMeshManager : MonoBehaviour
{
    public NavMeshSurface surface;

    void Start()
    {
        surface.BuildNavMesh(); // Build once at start
    }

    public void RebuildNavMesh()
    {
        surface.BuildNavMesh(); // Call this if you spawn new chunks dynamically
    }
}
