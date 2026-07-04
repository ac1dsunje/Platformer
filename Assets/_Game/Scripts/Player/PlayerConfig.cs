using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Game/Player/Spawn Config")]
public class PlayerConfig: ScriptableObject
{
    [field: SerializeField] public GameObject Prefab { get; private set; }
    [field: SerializeField] public Sprite Sprite { get; private set; }
    [field: SerializeField] public Vector2 SpawnPosition { get; private set; }

    [Header("Movement")]
    [field: SerializeField] public float MovementSpeed { get; private set; }
}