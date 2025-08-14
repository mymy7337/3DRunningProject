using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        // ���߿�
    }

    public void ReStart()
    {
        // Ȥ�� �𸣴�
    }
}
