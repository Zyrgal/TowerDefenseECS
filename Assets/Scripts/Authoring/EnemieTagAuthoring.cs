using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class EnemieTagAuthoring : MonoBehaviour
{
    public class Baker : Baker<EnemieTagAuthoring>
    {
        public override void Bake(EnemieTagAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent(entity, new EnemieTagComponent());
        }
    }
}
