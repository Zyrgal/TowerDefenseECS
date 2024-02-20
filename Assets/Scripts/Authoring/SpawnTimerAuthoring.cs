using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class SpawnTimerAuthoring : MonoBehaviour
{
    public float timerValue;
    public float timerReference;

    public class Baker : Baker<SpawnTimerAuthoring>
    {
        public override void Bake(SpawnTimerAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.None);

            AddComponent(entity, new SpawnTimer
            {
                timerValue = authoring.timerValue,
                timerReference = authoring.timerReference
            });
        }
    }


}
