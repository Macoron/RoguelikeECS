using System;
using Unity.Mathematics;

[Flags]
public enum Direction
{
    NONE = 0,
    NORD = 1,
    EAST = 2,
    SOUTH = 4,
    WEST = 8,
    NORD_EAST = NORD | EAST,
    SOUTH_EAST = SOUTH | EAST,
    SOUTH_WEST = SOUTH | WEST,
    NORD_WEST = NORD | WEST
}

public static class DirectionExtensions
{
    public static int2 ToInt2(this Direction dir)
    {
        var vec = new int2();
        if (dir.HasFlag(Direction.NORD))
            vec.y++;
        else if (dir.HasFlag(Direction.SOUTH))
            vec.y--;

        if (dir.HasFlag(Direction.EAST))
            vec.x++;
        else if (dir.HasFlag(Direction.WEST))
            vec.x--;

        return vec;
    }
}