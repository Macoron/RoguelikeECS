using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickedController
{
    private static List<ITickable> allTickable = new List<ITickable>();
    public static List<ITickable> AllTickable { get => allTickable; }

    public static void RegisterTickable(ITickable tickable)
    {
        allTickable.Add(tickable);
    }

    public static void Tick()
    {
        foreach (var tickable in allTickable)
            tickable.OnTick();
    }

}
