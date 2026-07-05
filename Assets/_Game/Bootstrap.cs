using UnityEngine;

public class Bootstrap: MonoBehaviour
{
    [Scene]
    [SerializeField] private string _loadingScene;

    [Scene]
    [SerializeField] private string _gamePlayScene;

    [Scene]
    [SerializeField] private string _mainMenuScene;

    private void Awake()
    {
        SceneLoader.SetScenes(_loadingScene, _gamePlayScene, _mainMenuScene);

        SceneLoader.SetMainMenuScene();
    }
}