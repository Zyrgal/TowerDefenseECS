using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public struct SpawnerProperties : IComponentData
{
    public int NumberEnnemieToSpawn;
    public Entity EnemiePrefab;
    public float3 SpawnerPosition;
    public float EnemieSpawnRate;
}