using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // === 다른 매니저 호출 ===
    public ScoreManager ScoreManager { get; private set; }

    // === 싱글톤 선언 ===
    public static GameManager Instance { get; private set; }


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);

        // === ScoreManager 생성 ===
        GameObject ScoreManagerObject = new GameObject("ScoreManager");
        ScoreManager = ScoreManagerObject.AddComponent<ScoreManager>();
        ScoreManagerObject.transform.SetParent(transform);
    }

    public void GameOver()
    {
        Time.timeScale = 0.0f;
        // 나중에
    }

    public void ReStart()
    {
        Time.timeScale = 1.0f;

        // === 현재 씬을 재로드 ===
        SceneManager.LoadScene("MainScene");
    }
}
