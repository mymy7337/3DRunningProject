using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : Singleton<TitleManager>
{
    // === ������ ����� �ؽ�Ʈ ===
    public TextMeshProUGUI highScore;
    public TextMeshProUGUI score;
    public TextMeshProUGUI time;
    public GameObject endPanel;

    // === �ٸ� �Ŵ��� ȣ�� ===
    public ScoreManager ScoreManager { get; private set; }

    protected override void Awake()
    {
        // === ���ʸ� �̱����� Awake�� �ҷ��� ===
        base.Awake();

        // === ScoreManager ���� ===
        GameObject ScoreManagerObject = new GameObject("ScoreManager");
        ScoreManager = ScoreManagerObject.AddComponent<ScoreManager>();
        ScoreManagerObject.transform.SetParent(transform);

        endPanel.SetActive(false);
    }

    public void Update()
    {

    }

    // === ���� ������ ȣ�� ===
    public void GameOver()
    {
        endPanel.SetActive(true);

        ScoreManager.FinalScore();

        Time.timeScale = 0.0f;
    }

    // === ���� ����۽� ��ư�� �Ҵ� ===
    public void ReStart()
    {
        Time.timeScale = 1.0f;

        // === ���� �Ŵ����� ���� ===
        if (Instance != null)
        {
            Destroy(Instance.gameObject);
        }

        // === ���� ���� ��ε� ===
        SceneManager.LoadScene("MainScene");

        endPanel.SetActive(false);
    }
}
