using System.Collections;
using System.Collections.Generic;
using Roguelike.ScriptableObjects;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapConverter : MonoBehaviour, IConvertGameObjectToEntity
{
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        var tilemapVisual = GetComponent<Tilemap>();
        var tilemapSize = tilemapVisual.size;
        var tilemapOrigin = tilemapVisual.origin;
        
        Debug.LogFormat("Tilemap size: {0}x{1}", tilemapSize.x, tilemapSize.y);
        
        var cellArch = dstManager.CreateArchetype(typeof(GridPos));
        var entityGrid = new NativeArray2D<Entity>(tilemapSize.x, tilemapSize.y, 
            tilemapOrigin.ToInt2(), Allocator.Persistent);
        dstManager.CreateEntity(cellArch, entityGrid.FlattenArray);
        
        Debug.LogFormat("Total tiles created: {0}", entityGrid.TotalSize);
        
        for (int x = tilemapOrigin.x; x < tilemapSize.x + tilemapOrigin.x; x++)
        for (int y = tilemapOrigin.y; y < tilemapSize.y + tilemapOrigin.y; y++)
        {
            var pos = new int2(x, y);
            
            // Setup pose
            var e = entityGrid[pos];
            dstManager.SetComponentData(e, new GridPos() { Value = pos });
            
            // Is there any tile?
            var tile = tilemapVisual.GetTile<RoguelikeTile>(pos.ToVector3Int());
            if (tile != null)
            {
                // Now check if it's obstacle
                if (tile.isObstacle)
                {
                    dstManager.AddComponentData(e, default(ObstacleComponent));
                }
            }
        }
        
        // Now we create grid entity
        dstManager.AddSharedComponentData(entity, new TilemapComponent()
        {
            Value = entityGrid
        });
        Debug.LogFormat("Grid creation finished!");
    }
}
