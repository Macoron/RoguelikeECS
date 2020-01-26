using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

[UpdateBefore(typeof(MovementUpdateGroup))]
public class BeforeMovementUpdateGroup : ComponentSystemGroup { }

public class MovementUpdateGroup : ComponentSystemGroup { }

[UpdateAfter(typeof(MovementUpdateGroup))]
public class AfterMovementUpdateGroup : ComponentSystemGroup { }