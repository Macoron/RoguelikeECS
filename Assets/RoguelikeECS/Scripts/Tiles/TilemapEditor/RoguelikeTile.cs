using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Roguelike.ScriptableObjects
{
    public class RoguelikeTile : Tile
    {
        [Header("Custom fields")]
        public bool isObstacle;
    }
}
