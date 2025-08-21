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

    [Header("Distance")]
    public TextMeshProUGUI distance;

    protected override bool isDestroy => true;

    protected override void Awake()
    {
        // === 제너릭 싱글톤의 Awake를 불러옴 ===
        base.Awake();

        endPanel.SetActive(false);

        Time.timeScale = 1.0f;
    }

    // === 게임 오버시 호출 ===
    public void GameOver()
    {
        endPanel.SetActive(true);

        ScoreManager.Instance.FinalScore();

        Time.timeScale = 0.0f;
    }

}
