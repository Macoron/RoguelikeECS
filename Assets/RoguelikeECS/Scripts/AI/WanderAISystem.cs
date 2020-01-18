using System.Collections;
using System.Collections.Generic;
using Unity.Entities;

using System.Linq;
using Unity.Mathematics;

public class WanderAISystem : TickedComponentSystem
{
    private static Direction[] allDirection = new Direction[]
    {
        Direction.NORD, Direction.SOUTH, Direction.EAST, Direction.WEST
    };

    private Random random;

    protected override void OnCreate()
    {
        base.OnCreate();
        random = new Random(1337);
    }

    protected override void OnTick()
    {
        Entities.ForEach((Entity e, ref WanderAIComponent wander) =>
        {
            // select random direction
            var index = random.NextInt(allDirection.Length);
            var dir = allDirection[index];

            // create a new intent
            var newIntent = PostUpdateCommands.CreateEntity();
            PostUpdateCommands.AddComponent(newIntent, new MoveIntentComponent()
            {
                target = e,
                direction = dir
            });
        });
    }
}
