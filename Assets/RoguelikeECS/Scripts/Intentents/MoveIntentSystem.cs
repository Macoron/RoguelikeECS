using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class MoveIntentSystem : TickedComponentSystem
{
    protected override void OnTick()
    {
        Entities.ForEach((Entity intent, ref MoveIntentComponent movement) =>
        {
            var allGridPos = GetComponentDataFromEntity<GridPos>();
            if (allGridPos.HasComponent(movement.target))
            {
                var curGridPos = allGridPos[movement.target];
                curGridPos.Value += movement.direction.ToInt2();

                if (TilemapUtils.IsValidPos(curGridPos.Value, EntityManager))
                {
                    PostUpdateCommands.SetComponent(movement.target, curGridPos);
                }

            }

            PostUpdateCommands.DestroyEntity(intent);
        });
    }



}
