using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovementSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        var input = GetSingleton<InputComponent>();
        
        Entities.ForEach<PlayerComponent>((Entity e, ref PlayerComponent player) =>
        {
            var direction = new int2();
            
            if (input.upPressed)
                direction.y++;
            if (input.downPressed)
                direction.y--;

            if (input.leftPressed)
                direction.x--;
            if (input.rightPressed)
                direction.x++;

            if (direction.x != 0 || direction.y != 0)
            {
                var newIntent = PostUpdateCommands.CreateEntity();
                PostUpdateCommands.AddComponent<MoveIntentComponent>(newIntent, new MoveIntentComponent()
                {
                    target = e,
                    direction = direction
                });
            }
        });
    }


}
