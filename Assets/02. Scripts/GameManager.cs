using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // === 점수를 띄어줄 텍스트 ===
    public Text score;
    public GameObject endPanel;

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
        endPanel.SetActive(true);

        ScoreManager.UpDateTimer();

        Time.timeScale = 0.0f;
    }

    public void ReStart()
    {
        endPanel.SetActive(false);

        Time.timeScale = 1.0f;

        // === 현재 씬을 재로드 ===
        SceneManager.LoadScene("MainScene");
    }
}
