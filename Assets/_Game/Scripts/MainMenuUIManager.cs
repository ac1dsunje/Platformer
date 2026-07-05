using UnityEngine;
using UnityEngine.UI;

public class MainMenuUIManager: MonoBehaviour
{
    [SerializeField] private Button _playButton;

    private void Awake()
    {
        _playButton.onClick.AddListener(SetGamePlayScene);
    }

    private void SetGamePlayScene()
    {
        SceneLoader.SetGamePlayScene();
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(SetGamePlayScene);
    }
}