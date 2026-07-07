using _Game.Scripts.Player.Interfaces;
using UnityEngine;

namespace _Game.Scripts.Level.Spike
{
public class SpikeController: MonoBehaviour
{
    [SerializeField] private int _damage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.TryGetComponent<IDamageAble>(out var damageable))
        {
            damageable.TakeDamage(_damage);
        }
    }
}
}