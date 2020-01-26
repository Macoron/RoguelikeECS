using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public struct GridPos : IComponentData
{
    public int2 Value;

    public static bool operator == (GridPos grid1,
                                         GridPos grid2)
    {
        return grid1.Equals(grid2);
    }

    public static bool operator !=(GridPos grid1,
                                     GridPos grid2)
    {
        return !grid1.Equals(grid2);
    }
}
