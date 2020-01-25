using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class TilemapLifecycleSystem : ComponentSystem, IResetable
{
    protected override void OnUpdate()
    {
        
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        Reset();
    }

    public void Reset()
    {
        var gridEntities = new List<TilemapComponent>();
        EntityManager.GetAllUniqueSharedComponentData<TilemapComponent>(gridEntities);
        foreach (var gridEntity in gridEntities)
        {
            if (gridEntity.Value.TotalSize == 0)
                continue;
            gridEntity.Value.Dispose();
        }
    }
}
