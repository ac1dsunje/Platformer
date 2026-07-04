using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosition;

    public Transform GetSpawnPosition => _spawnPosition;

}
