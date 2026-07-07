using UnityEngine;

namespace _Game.Scripts.Boot
{
public class CoroutineRunner : MonoBehaviour
{
    private void Awake() => DontDestroyOnLoad(gameObject);
}
}