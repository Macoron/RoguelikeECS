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
            upPressed = Input.GetKey(KeyCode.W),
            downPressed = Input.GetKey(KeyCode.S),
            leftPressed = Input.GetKey(KeyCode.A),
            rightPressed = Input.GetKey(KeyCode.D)
        });
        
    }
}
