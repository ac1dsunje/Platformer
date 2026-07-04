using UnityEngine;

[CreateAssetMenu(fileName = "HealthConfig", menuName = "Game/Health/Config")]
public class HealthConfig : ScriptableObject
{
    [field: SerializeField] public int MaxHealth { get; private set; }
}