using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using Unity.Mathematics;
using UnityEditor.Search;
using Unity.Burst;
using System.Runtime.CompilerServices;

public partial struct SpawnerSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<SpawnerProperties>();
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        SpawnerProperties spawnerProperties = SystemAPI.GetSingleton<SpawnerProperties>();

        /*var deltaTime = SystemAPI.Time.DeltaTime;
        var ecbSingleton = SystemAPI.GetSingleton<BeginInitializationEntityCommandBufferSystem.Singleton>();

        SpawnEnnemieJob SpawningEnemieJob = new SpawnEnnemieJob()
        {
            DeltaTime = deltaTime,
            ecb = ecbSingleton.CreateCommandBuffer(state.WorldUnmanaged)
        };

        state.Dependency = SpawningEnemieJob.Schedule(state.Dependency);*/

        RefRW<SpawnTimer> spawnTimer = SystemAPI.GetSingletonRW<SpawnTimer>();

        spawnTimer.ValueRW.timerValue -= SystemAPI.Time.DeltaTime;

        if (spawnTimer.ValueRW.timerValue <= 0)
        {
            float3 basePositionToSpawn = new();

            foreach (RefRO<LocalTransform> spawner in SystemAPI.Query<RefRO<LocalTransform>>().WithAll<SpawnerProperties>())
            {
                basePositionToSpawn = spawner.ValueRO.Position;
            }

            Entity spawnedEntity = state.EntityManager.Instantiate(spawnerProperties.EnemiePrefab);

            state.EntityManager.SetComponentData(spawnedEntity, new LocalTransform
            {
                Position = basePositionToSpawn,
                Rotation = quaternion.identity,
                Scale = 1f
            });

            for (int i = 0; i < spawnerProperties.NumberEnnemieToSpawn; i++)
            {
                
            }

            spawnTimer.ValueRW.timerValue = spawnTimer.ValueRW.timerReference;
        }                
    }

    [BurstCompile]
    public partial struct SpawnEnnemieJob : IJobEntity
    {
        public float DeltaTime;
        public EntityCommandBuffer ecb;

        [BurstCompile]
        public void Execute(in SpawnerProperties spawnerProperties, SpawnerAspect spawnerAspect)
        {
            spawnerAspect.SpawnTimer -= DeltaTime;

            if (!spawnerAspect.TimeToSpawnEnemie) return;

            spawnerAspect.SpawnTimer = spawnerProperties.EnemieSpawnRate;
            var newEnemie = ecb.Instantiate(spawnerAspect.EnemiePrefab);
        }
    }

}
