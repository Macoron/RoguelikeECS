using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class EndGameFlagConverter : MonoBehaviour, IConvertGameObjectToEntity
{
    public Grid grid;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        var worldPos = grid.WorldToCell(transform.position);
        dstManager.AddComponentData(entity, new GridPos()
        {
            Value = new int2(worldPos.x, worldPos.y)
        });

        dstManager.AddComponentData(entity, default(CopyTransformToGameObject));

        dstManager.AddComponent<EndGameFlagComponent>(entity);
    }
}
