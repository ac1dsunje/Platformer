using UnityEngine;

namespace _Game.Scripts.Boot
{
public class Bootstrap: MonoBehaviour
{
    [Scene]
    [SerializeField] private string _loadingScene;

    [Scene]
    [SerializeField] private string _gamePlayScene;

    [Scene]
    [SerializeField] private string _mainMenuScene;

    [SerializeField] private CoroutineRunner _coroutineRunner;

    private void Awake()
    {
        SceneLoader.Construct(_loadingScene, _gamePlayScene, _mainMenuScene, _coroutineRunner);

        SceneLoader.SetMainMenuScene();
    }
}
}