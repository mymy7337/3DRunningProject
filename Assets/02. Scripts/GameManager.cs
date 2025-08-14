using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
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
        Time.timeScale = 0.0f;
        // ���߿�
    }

    public void ReStart()
    {
        Time.timeScale = 1.0f;

        // === ���� ���� ��ε� ===
        SceneManager.LoadScene("MainScene");
    }
}
