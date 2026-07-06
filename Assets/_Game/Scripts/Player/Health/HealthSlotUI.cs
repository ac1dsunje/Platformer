using UnityEngine;
using UnityEngine.UI;

public class HealthSlotUI: MonoBehaviour
{
    [SerializeField] private Sprite _acitve;
    [SerializeField] private Sprite _inactive;
    [SerializeField] private Image _slot;

    public void Set()
    {
        _slot.sprite = _acitve;
    }

    public void UnSet()
    {
        _slot.sprite = _inactive;
    }
}