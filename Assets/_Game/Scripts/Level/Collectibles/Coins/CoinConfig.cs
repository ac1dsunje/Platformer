using UnityEngine;

namespace _Game.Scripts.Level.Collectibles.Coins
{
[CreateAssetMenu(fileName = "Coin Config", menuName = "Game/Collectibles/Coin config")]
public class CoinConfig: ScriptableObject
{
    [field: SerializeField] public float RotationSpeedMax { get; private set; }
    [field: SerializeField] public float RotationSpeedMin { get; private set; }

    [field: SerializeField] public int Value { get; private set; }
}
}