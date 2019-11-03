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
                curPos.y++;
            if (input.downPressed)
                curPos.y--;

            if (input.leftPressed)
                curPos.x--;
            if (input.rightPressed)
                curPos.x++;

            pos.Value = curPos;
        });
    }
}
