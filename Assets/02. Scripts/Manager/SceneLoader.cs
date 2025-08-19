using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : Singleton<SceneLoader>
{
    protected override bool isDestroy => false;

    protected override void Awake()
    {
        base.Awake(); // 제너릭 싱글톤의 Awake를 불러옴
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(SceneNames.StartScene);
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene(SceneNames.MainScene);
    }

    public void LoadPlayScene()
    {
        SceneManager.LoadScene(SceneNames.PlayScene);
    }

    public void LoadCustomizingScene()
    {
        SceneManager.LoadScene(SceneNames.CustomizeScene);
    }

    public void RestartGame()
    {
        LoadPlayScene();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
