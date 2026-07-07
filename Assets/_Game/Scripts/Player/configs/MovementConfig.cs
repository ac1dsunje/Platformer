using UnityEngine;

namespace _Game.Scripts.Player.configs
{
[CreateAssetMenu(fileName = "MovementConfig", menuName = "Game/Movement/Config")]
public class MovementConfig: ScriptableObject
{
    [field: SerializeField] public float MovementSpeed { get; private set; } = 4f;
    [field: SerializeField] public float JumpForce { get; private set; } = 7f;
}
}