using UnityEngine.SceneManagement;

public static class SceneLoader
{
    private static string _loadingScene;
    private static string _gamePlayScene;
    private static string _mainMenuScene;

    public static void SetScenes(string loadingScene, string gamePlayScene, string mainMenuScene)
    {
        _loadingScene = loadingScene;
        _gamePlayScene = gamePlayScene;
        _mainMenuScene = mainMenuScene;
    }

    public static void SetMainMenuScene()
    {
        LoadScene(_mainMenuScene);
    }

    public static void SetGamePlayScene()
    {
        LoadScene(_gamePlayScene);
    }

    private static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}