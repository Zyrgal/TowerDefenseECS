using Unity.Entities;

public partial struct SpawnTimer : IComponentData
{
    public float timerValue;
    public float timerReference;
}
