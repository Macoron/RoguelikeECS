using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovementSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        if (!HasSingleton<InputComponent>())
            return;

        var input = GetSingleton<InputComponent>();
        
        Entities.ForEach((Entity e, ref PlayerComponent player) =>
        {
            var direction = Direction.NONE;

            if (input.upPressed)
                direction |= Direction.NORD;
            if (input.downPressed)
                direction |= Direction.SOUTH;

            if (input.leftPressed)
                direction |= Direction.WEST;
            if (input.rightPressed)
                direction |= Direction.EAST;

            if (direction != Direction.NONE)
            {
                var newIntent = PostUpdateCommands.CreateEntity();
                PostUpdateCommands.AddComponent(newIntent, new MoveIntentComponent()
                {
                    target = e,
                    direction = direction
                });

                // We made a move, now need to update game
                TickedController.MakeTick();
            }
        });
    }


}
