using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public struct TilemapComponent : ISharedComponentData, IEquatable<TilemapComponent>
{
    public NativeArray2D<Entity> Value;

    #region Equal

    public bool Equals(TilemapComponent other)
    {
        return Value.Equals(other.Value);
    }

    public override bool Equals(object obj)
    {
        return obj is TilemapComponent other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    #endregion
}
