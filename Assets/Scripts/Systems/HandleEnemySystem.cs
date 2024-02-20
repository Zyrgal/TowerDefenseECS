using Unity.Entities;
using Unity.Transforms;
using UnityEditor;

public partial struct HandleEnemySystem : ISystem
{
    public void OnUpdate(ref SystemState state)
    {
        foreach (MovingAspect movingAspect in 
            SystemAPI.Query<MovingAspect>().WithAll<EnemieTagComponent>())
        {
            movingAspect.Move(SystemAPI.Time.DeltaTime);
        }
    }
}
