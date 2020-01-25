using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class SceneControl
{
    public static void DestroyScene()
    {
        var manager = World.DefaultGameObjectInjectionWorld.EntityManager;
        manager.DestroyEntity(manager.UniversalQuery);
    }
}
