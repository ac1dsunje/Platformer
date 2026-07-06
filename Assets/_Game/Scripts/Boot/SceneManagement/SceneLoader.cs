using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    private static string _loadingScene;
    private static string _gamePlayScene;
    private static string _mainMenuScene;

    private static CoroutineRunner _coroutineRunner;

    public static void Construct(string loadingScene, string gamePlayScene, string mainMenuScene, CoroutineRunner coroutineRunner)
    {
        _loadingScene = loadingScene;
        _gamePlayScene = gamePlayScene;
        _mainMenuScene = mainMenuScene;
        _coroutineRunner = coroutineRunner;
    }

    public static void SetGamePlayScene()
    {
        _coroutineRunner.StartCoroutine(LoadScene(_gamePlayScene));
    }

    public static void SetMainMenuScene()
    {
        _coroutineRunner.StartCoroutine(LoadScene(_mainMenuScene));
    }

    public static void ReloadGamePlay()
    {
        SetGamePlayScene();
    }

    private static IEnumerator LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(_loadingScene);
        AsyncOperation waitLoading = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        yield return new WaitUntil(() => waitLoading.isDone);

        SceneManager.UnloadSceneAsync(_loadingScene);
    }
}