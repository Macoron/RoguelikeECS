using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class PlayerConverter : MonoBehaviour, IConvertGameObjectToEntity
{
    public Grid grid;
    public float maxHealth = 100f;
    
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new PlayerComponent());

        var worldPos = grid.WorldToCell(transform.position);
        dstManager.AddComponentData(entity, new GridPos()
        {
            Value = new int2(worldPos.x, worldPos.y)
        });
        
        dstManager.AddComponentData(entity, default(CopyTransformToGameObject));
        
        // Player need health
        dstManager.AddComponentData(entity, new HealthComponent() {health = maxHealth});
    }
}
