using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Game/Player/Spawn Config")]
public class PlayerConfig: ScriptableObject
{
    [field: SerializeField] public GameObject Prefab { get; private set; }
    [field: SerializeField] public float MovementSpeed { get; private set; }
}