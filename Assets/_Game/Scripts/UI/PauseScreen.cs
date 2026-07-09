using _Game.Scripts.GamePlay;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Scripts.UI
{
public class PauseScreen : ScreenManager
{
    [SerializeField] private Button _resume;
    [SerializeField] private Button _exit;
    [SerializeField] private Button _restart;

    private GameStateManager _gameStateManager;

    public void Construct(GameStateManager gsm)
    {
        _gameStateManager = gsm;
        _resume.onClick.AddListener(ResumeGame);
        _exit.onClick.AddListener(ExitToMainMenu);
        _restart.onClick.AddListener(Restart);
        _restart.onClick.AddListener(Restart);
    }

    private void ResumeGame()
    {
        _gameStateManager.ResumeGame();
    }

    private void ExitToMainMenu()
    {
        _gameStateManager.GoToMainMenu();
    }

    private void Restart()
    {
        _gameStateManager.RestartGameOnButton();
    }

    private void OnDestroy()
    {
        _resume.onClick.RemoveListener(ResumeGame);
        _exit.onClick.RemoveListener(ExitToMainMenu);
        _restart.onClick.RemoveListener(Restart);
    }
}
}