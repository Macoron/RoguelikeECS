using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public abstract class TickedComponentSystem : ComponentSystem, ITickable
{
    protected override void OnCreate()
    {
        base.OnCreate();
    }

    protected override void OnUpdate()
    {
        // usualy - do nothing, we care only about ticks
    }

    public abstract void OnTick();
}
