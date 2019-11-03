﻿using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class PlayerConverter : MonoBehaviour, IConvertGameObjectToEntity
{
    public Grid grid;
    
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new PlayerComponent());

        var worldPos = grid.WorldToCell(transform.position);
        dstManager.AddComponentData(entity, new GridPos()
        {
            Value = new int2(worldPos.x, worldPos.y)
        });
    }
}