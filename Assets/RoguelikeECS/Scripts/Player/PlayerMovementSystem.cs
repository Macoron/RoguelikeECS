using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovementSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        var input = GetSingleton<InputComponent>();
        
        Entities.ForEach<PlayerComponent, GridPos>((ref PlayerComponent player, ref GridPos pos) =>
        {
            var newPos = pos.Value;
            
            if (input.upPressed)
                newPos.y++;
            if (input.downPressed)
                newPos.y--;

            if (input.leftPressed)
                newPos.x--;
            if (input.rightPressed)
                newPos.x++;

            if (IsValidPos(newPos))
            {
                pos.Value = newPos;
            }
            

        });
    }

    private bool IsValidPos(int2 newPos)
    {
        var gridEntities = new List<TilemapComponent>();
        EntityManager.GetAllUniqueSharedComponentData<TilemapComponent>(gridEntities);

        foreach (var tilemap in gridEntities)
        {
            if (tilemap.Value.TotalSize == 0)
                continue;;

            var entityTile = tilemap.Value[newPos];
            var isObstacle = EntityManager.HasComponent<ObstacleComponent>(entityTile);
            return !isObstacle;
        }

        return false;
    }
}
