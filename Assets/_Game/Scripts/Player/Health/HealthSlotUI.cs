using UnityEngine;
using UnityEngine.UI;

namespace _Game.Scripts.Player.Health
{
public class HealthSlotUI: MonoBehaviour
{
    [SerializeField] private Sprite _active;
    [SerializeField] private Sprite _inactive;
    [SerializeField] private Image _slot;

    public void Set()
    {
        _slot.sprite = _active;
    }

    public void UnSet()
    {
        _slot.sprite = _inactive;
    }
}
}