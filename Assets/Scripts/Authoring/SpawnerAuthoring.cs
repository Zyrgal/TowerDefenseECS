using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class SpawnerAuthoring : MonoBehaviour
{
    public int NumberEnnemieToSpawn;
    public GameObject EnemiePrefab;
    [HideInInspector] public float3 spawnerPosition;
    public float EnemieSpawnRate;
}

public class SpawnerMonoBaker : Baker<SpawnerAuthoring>
{
    public override void Bake(SpawnerAuthoring authoring)
    {
        if (authoring.EnemiePrefab == null)
        {
            return;
        }

        Entity entity = GetEntity(TransformUsageFlags.Dynamic);

        AddComponent(entity, new SpawnerProperties
        {
            EnemiePrefab = GetEntity(authoring.EnemiePrefab,TransformUsageFlags.Dynamic),
            NumberEnnemieToSpawn = authoring.NumberEnnemieToSpawn,
            EnemieSpawnRate = authoring.EnemieSpawnRate,
        });
    }
}
