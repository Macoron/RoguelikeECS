using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickedController
{
    public static List<ITickable> AllTickable { get; } = new List<ITickable>();

    public static void RegisterTickable(ITickable tickable)
    {
        AllTickable.Add(tickable);
    }

    public static void MakeTick()
    {
        foreach (var tickable in AllTickable)
            tickable.OnTickRecived();
    }

}
