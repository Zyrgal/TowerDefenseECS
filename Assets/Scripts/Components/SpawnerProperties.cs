using Unity.Entities;
using UnityEngine;

public struct SpawnerProperties : IComponentData
{
    public int NumberEnnemieToSpawn;
    public Entity EnemiePrefab;
}