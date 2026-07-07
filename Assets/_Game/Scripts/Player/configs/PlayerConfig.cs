using UnityEngine;

namespace _Game.Scripts.Player.configs
{
[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Game/Player/Spawn Config")]
public class PlayerConfig: ScriptableObject
{
    [field: SerializeField] public GameObject Prefab { get; private set; }
    [field: SerializeField] public MovementConfig MovementConfig { get; private set; }
    [field: SerializeField] public HealthConfig HealthConfig { get; private set;  }
}
}