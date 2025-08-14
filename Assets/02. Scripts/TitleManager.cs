using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    // === ������ ����� �ؽ�Ʈ ===
    public TextMeshProUGUI score;
    public TextMeshProUGUI time;
    public GameObject endPanel;

    // === �ٸ� �Ŵ��� ȣ�� ===
    public ScoreManager ScoreManager { get; private set; }

    // === �̱��� ���� ===
    public static TitleManager Instance { get; private set; }


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

        endPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            GameOver(); // Ȯ�ο�
        }
    }

    // === ���� ������ ȣ�� ===
    public void GameOver()
    {
        endPanel.SetActive(true);

        ScoreManager.UpDateTimer();

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
            Instance = null;
        }

        // === ���� ���� ��ε� ===
        SceneManager.LoadScene("MainScene");

        endPanel.SetActive(false);
    }
}
