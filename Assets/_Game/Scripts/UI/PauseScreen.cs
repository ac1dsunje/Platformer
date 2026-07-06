using UnityEngine;
using UnityEngine.UI;

public class PauseScreen : ScreenManager
{
    [SerializeField] private Button _resume;
    [SerializeField] private Button _exit;

    private GameStateManager _gameStateManager;

    public PauseScreen Initialize(GameStateManager gsm)
    {
        _gameStateManager = gsm;
        _resume.onClick.AddListener(ResumeGame);
        _exit.onClick.AddListener(ExitToMainMenu);

        return this;
    }

    private void ResumeGame()
    {
        _gameStateManager.ResumeGame();
}

    private void ExitToMainMenu()
    {
        SceneLoader.SetMainMenuScene();
    }

    private void OnDestroy()
    {
        _resume.onClick.RemoveListener(ResumeGame);
        _exit.onClick.RemoveListener(ExitToMainMenu);
    }
}