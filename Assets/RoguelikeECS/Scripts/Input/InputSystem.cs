using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class InputSystem : ComponentSystem
{
    protected override void OnCreate()
    {
        base.OnCreate();
        
        // Init singleton for input
        EntityManager.CreateEntity(typeof(InputComponent));
        SetSingleton(new InputComponent());
    }

    protected override void OnUpdate()
    {
        // simple WASD controls
        SetSingleton(new InputComponent()
        {
            upPressed = Input.GetKeyDown(KeyCode.W),
            downPressed = Input.GetKeyDown(KeyCode.S),
            leftPressed = Input.GetKeyDown(KeyCode.A),
            rightPressed = Input.GetKeyDown(KeyCode.D)
        });
        
    }
}
