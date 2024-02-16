using Unity.Entities;
using UnityEngine;

public class SpawnerMono : MonoBehaviour
{
    public int NumberEnnemieToSpawn;
    public GameObject EnemiePrefab;
}

public class SpawnerMonoBaker : Baker<SpawnerMono>
{
    public override void Bake(SpawnerMono authoring)
    {
        if (authoring.EnemiePrefab == null)
        {
            return;
        }

        Entity entity = GetEntity(TransformUsageFlags.Dynamic);

        AddComponent(entity, new SpawnerProperties
        {
            EnemiePrefab = GetEntity(authoring.EnemiePrefab,TransformUsageFlags.Dynamic),
            NumberEnnemieToSpawn = authoring.NumberEnnemieToSpawn
        });
    }
}
