using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class SceneControl : ComponentSystem
{
    public static void DestroyCurrentScene()
    {
        var inst = World.DefaultGameObjectInjectionWorld.GetOrCreateSystem<SceneControl>();
        inst.DestroyScene();
    }

    public void DestroyScene()
    {
        // First, reset all systems
        foreach (var sys in World.Systems)
        {
            var resetable = sys as IResetable;
            resetable?.Reset();
        }

        // Now destroy all entites non-permanent tag
        var query = Entities.WithNone<PersistentComponent>().ToEntityQuery();
        EntityManager.DestroyEntity(query);
    }

    protected override void OnUpdate()
    {
    }
}
