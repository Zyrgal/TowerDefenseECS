using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public readonly partial struct MovingAspect : IAspect
{
    public readonly RefRW<LocalTransform> localTransform;
    public readonly RefRW<MovementComponent> movement;

    public void Move(float deltaTime)
    {
        localTransform.ValueRW = localTransform.ValueRO.Translate(movement.ValueRO.movementVector * deltaTime);
    }
}
