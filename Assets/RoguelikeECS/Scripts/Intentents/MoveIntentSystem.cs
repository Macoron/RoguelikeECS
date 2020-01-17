using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class MoveIntentSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((Entity intent, ref MoveIntentComponent movement) =>
        {
            var allGridPos = GetComponentDataFromEntity<GridPos>();
            if (allGridPos.HasComponent(movement.target))
            {
                var curGridPos = allGridPos[movement.target];
                curGridPos.Value += movement.direction;

                if (IsValidPos(curGridPos.Value))
                {
                    PostUpdateCommands.SetComponent(movement.target, curGridPos);
                }

            }

            PostUpdateCommands.DestroyEntity(intent);
        });
    }

    private bool IsValidPos(int2 newPos)
    {
        var gridEntities = new List<TilemapComponent>();
        EntityManager.GetAllUniqueSharedComponentData<TilemapComponent>(gridEntities);

        foreach (var tilemap in gridEntities)
        {
            if (tilemap.Value.TotalSize == 0)
                continue;

            if (!tilemap.Value.InBounds(newPos))
                return false;

            var entityTile = tilemap.Value[newPos];
            var isObstacle = EntityManager.HasComponent<ObstacleComponent>(entityTile);
            return !isObstacle;
        }

        return false;
    }
}
