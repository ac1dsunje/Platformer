using UnityEngine;

namespace _Game.Scripts.Player.configs
{
[CreateAssetMenu(fileName = "HealthConfig", menuName = "Game/Health/Config")]
public class HealthConfig : ScriptableObject
{
    [field: SerializeField] public int MaxHealth { get; private set; }
}
}