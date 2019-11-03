using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class PlayerMovementSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        var input = GetSingleton<InputComponent>();
        
        Entities.ForEach<PlayerComponent, GridPos>((ref PlayerComponent player, ref GridPos pos) =>
        {
            var curPos = pos.Value;
            
            if (input.upPressed)
                curPos.x++;
            if (input.downPressed)
                curPos.x--;

            if (input.leftPressed)
                curPos.y--;
            if (input.rightPressed)
                curPos.y++;

            pos.Value = curPos;
        });
    }
}
