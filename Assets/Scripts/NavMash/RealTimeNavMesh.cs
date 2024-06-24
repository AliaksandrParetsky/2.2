using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class RealTimeNavMesh : MonoBehaviour
{
    [SerializeField] private List<NavMeshSurface> navMeshSurfaces;

    private void OnEnable()
    {
        MessageBroadcastSystem.AddListener(DoorsEvent.BAKE, Bake);
    }

    private void OnDisable()
    {
        MessageBroadcastSystem.RemoveListener(DoorsEvent.BAKE, Bake);
    }

    private void Bake()
    {
        foreach (var surface in navMeshSurfaces)
        {
            surface.BuildNavMesh();
        }
    }
}
