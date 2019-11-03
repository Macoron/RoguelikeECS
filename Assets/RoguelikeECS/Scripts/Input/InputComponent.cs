using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public struct InputComponent : IComponentData
{
    public bool upPressed;
    public bool downPressed;
    public bool leftPressed;
    public bool rightPressed;
}
