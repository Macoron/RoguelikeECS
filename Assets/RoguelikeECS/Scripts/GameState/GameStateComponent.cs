using System;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

public enum GameState
{
    IN_GAME = 0,
    FINISHED = 1
}

[Serializable]
public struct GameStateComponent : IComponentData
{
    public GameState state;
}
