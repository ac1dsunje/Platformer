using UnityEngine;

public abstract class ScreenManager: MonoBehaviour
{
    [SerializeField] private CanvasGroup _screen;

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