using _Game.Scripts.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreenUI: ScreenManager
{
    [SerializeField] private Image _loadingLogo;
    [SerializeField] private TextMeshProUGUI _loadingText;

    public void ShowMessage(string message)
    {
        _loadingText.text = message;
    }

    private void Update()
    {
        RotateLogo();
    }

    private void RotateLogo()
    {
        _loadingLogo.transform.Rotate(Vector3.forward * Time.unscaledDeltaTime * 100, Space.World);
    }
}