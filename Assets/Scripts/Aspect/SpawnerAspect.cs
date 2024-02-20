using Unity.Entities;

public readonly partial struct SpawnerAspect : IAspect
{
    private readonly RefRW<SpawnTimer> spawnTimer;
    private readonly RefRO<SpawnerProperties> spawnerProperties;

    public float SpawnTimer
    {
        get => spawnTimer.ValueRO.timerValue;
        set => spawnTimer.ValueRW.timerValue = value;
    }

    public bool TimeToSpawnEnemie => SpawnTimer <= 0;

    public float EnemieSpawnRate => spawnerProperties.ValueRO.EnemieSpawnRate;

    public Entity EnemiePrefab => spawnerProperties.ValueRO.EnemiePrefab;

}
