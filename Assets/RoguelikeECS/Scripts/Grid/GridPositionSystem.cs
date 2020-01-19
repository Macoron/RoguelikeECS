using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public class GridPositionSystem : ComponentSystem
{
    private Grid gridBehaviour;

    protected override void OnUpdate()
    {
        if (!gridBehaviour)
            gridBehaviour = GameObject.FindObjectOfType<Grid>();

        if (!gridBehaviour)
            return;

        Entities.ForEach<GridPos, Translation>((ref GridPos gridPos, ref Translation worldPos) =>
        {
            var newPos = gridPos.Value;
            var newWorldPos = gridBehaviour.GetCellCenterLocal(newPos.ToVector3Int());
            worldPos.Value = newWorldPos;
        });
    }
}
