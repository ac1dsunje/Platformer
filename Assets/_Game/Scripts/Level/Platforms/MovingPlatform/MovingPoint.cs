using System;
using UnityEngine;

namespace _Game.Scripts.Level.Platforms.MovingPlatform
{
[Serializable] 
public class MovingPoint
{
    [field: SerializeField] public Vector3 Point;
    [field: SerializeField] public bool SetPoint;
}
}