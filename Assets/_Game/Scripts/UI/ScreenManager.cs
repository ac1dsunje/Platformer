using UnityEngine;

namespace _Game.Scripts.UI
{
[RequireComponent(typeof(CanvasGroup))]
public abstract class ScreenManager: MonoBehaviour
{
    private CanvasGroup _screen;

    private void Awake()
    {
        _screen = GetComponent<CanvasGroup>();
    }

    public virtual void Show()
    {
        _screen.alpha = 1f;
        _screen.interactable = true;
        _screen.blocksRaycasts = true;
    }

    public virtual void Hide()
    {
        _screen.alpha = 0f;
        _screen.interactable = false;
        _screen.blocksRaycasts = false;
    }
}
}