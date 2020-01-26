using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using static Unity.Mathematics.math;

[UpdateInGroup(typeof(AfterMovementUpdateGroup))]
public class GameStateSystem : TickedComponentSystem
{
    protected override void OnTick()
    {
        // Get all players
        var players = Entities.WithAllReadOnly<PlayerComponent, GridPos>()
            .ToEntityQuery()
            .ToEntityArray(Allocator.TempJob);

        // Get all end game flags
        var flags = Entities.WithAllReadOnly<EndGameFlagComponent, GridPos>()
            .ToEntityQuery()
            .ToEntityArray(Allocator.TempJob);


        // check if each player reached flag
        bool playerWin = false;
        foreach (var player in players)
        {
            // get current player pos
            var playerPos = EntityManager.GetComponentData<GridPos>(player);

            foreach (var flag in flags)
            {
                // get current flag pos
                var flagPos = EntityManager.GetComponentData<GridPos>(flag);

                // player reached flag?
                if (playerPos == flagPos)
                {
                    playerWin = true;
                    break;
                }

            }

            // Get out if player reached flag
            if (playerWin)
                break;
        }

        if (playerWin)
            Debug.Log("You win!");

        players.Dispose();
        flags.Dispose();



        /*Entities.ForEach((ref PlayerComponent player, ref GridPos playerPos) =>
        {
            Entities.ForEach((ref EndGameFlagComponent flag, ref GridPos flagPos) =>
            {
                if (flagPos == playerPos)
                {
                    Debug.Log("You win!");
                }
            });
        });*/

    }
}