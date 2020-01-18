using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public struct MoveIntentComponent : IComponentData
{
    public Entity target;
    public Direction direction;
}
