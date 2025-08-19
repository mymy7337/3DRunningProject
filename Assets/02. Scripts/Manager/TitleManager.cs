using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : Singleton<TitleManager>
{
    // === 점수를 띄어줄 텍스트 ===
    public TextMeshProUGUI highScore;
    public TextMeshProUGUI score;
    public TextMeshProUGUI time;
    public GameObject endPanel;

    // === 다른 매니저 호출 ===
    public ScoreManager ScoreManager { get; private set; }

    protected override bool isDestroy => false;

    protected override void Awake()
    {
        // === 제너릭 싱글톤의 Awake를 불러옴 ===
        base.Awake();

        // === ScoreManager 생성 ===
        GameObject ScoreManagerObject = new GameObject("ScoreManager");
        ScoreManager = ScoreManagerObject.AddComponent<ScoreManager>();
        ScoreManagerObject.transform.SetParent(transform);

        endPanel.SetActive(false);
    }

    // === 게임 오버시 호출 ===
    public void GameOver()
    {
        endPanel.SetActive(true);

        ScoreManager.FinalScore();

        Time.timeScale = 0.0f;
    }

}
