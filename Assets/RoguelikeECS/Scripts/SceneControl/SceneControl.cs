using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class SceneControl : ComponentSystem
{
    public void DestroyScene()
    {
        EntityManager.DestroyEntity(EntityManager.UniversalQuery);
    }
}
