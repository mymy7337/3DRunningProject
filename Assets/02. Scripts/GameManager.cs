using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // === ������ ����� �ؽ�Ʈ ===
    public Text score;
    public GameObject endPanel;

    // === �ٸ� �Ŵ��� ȣ�� ===
    public ScoreManager ScoreManager { get; private set; }

    // === �̱��� ���� ===
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

        // === ScoreManager ���� ===
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

        // === ���� ���� ��ε� ===
        SceneManager.LoadScene("MainScene");
    }
}
