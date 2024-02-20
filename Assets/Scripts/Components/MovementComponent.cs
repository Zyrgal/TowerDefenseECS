using Unity.Entities;
using Unity.Mathematics;

public partial struct MovementComponent : IComponentData
{
    public float3 movementVector;
}
