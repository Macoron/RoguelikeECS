using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public static class MathConverters
{
    public static Vector3Int ToVector3Int(this int2 vec2)
    {
        return new Vector3Int(vec2.x, vec2.y, 0);
    }

    public static int2 ToInt2(this Vector3Int vec3)
    {
        return new int2(vec3.x, vec3.y);
    }
}
