using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class TilemapUtils : MonoBehaviour
{
    public static bool IsValidPos(int2 newPos, EntityManager manager)
    {
        var gridEntities = new List<TilemapComponent>();
        manager.GetAllUniqueSharedComponentData(gridEntities);

        foreach (var tilemap in gridEntities)
        {
            if (tilemap.Value.TotalSize == 0)
                continue;

            if (!tilemap.Value.InBounds(newPos))
                return false;

            var entityTile = tilemap.Value[newPos];
            var isObstacle = manager.HasComponent<ObstacleComponent>(entityTile);
            return !isObstacle;
        }

        return false;
    }
}
