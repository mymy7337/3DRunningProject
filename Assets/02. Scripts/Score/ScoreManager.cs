using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // === ������ ���� Ÿ�̸� ===
    private float timer;

    // === ���ӳ����� ��������, �ְ����� ���Ƿ� ���� ===
    private int highScore = 0;
    private int currentScore = 0;

    private void Start()
    {
        // === ScoreData���� ����� highScore�� �ҷ��� ===
        ScoreData loadedData = DataManager.Instance.Load();
        if (loadedData != null)
        {
            highScore = loadedData.highScore;
        }

        if (TitleManager.Instance != null)
        {
            timer = 0;
        }
    }

    private void FixedUpdate()
    {
        // === ��� �ڵ� ===
        if (TitleManager.Instance != null)
        {
            timer += Time.fixedDeltaTime;
        }
    }

    // === ���� �߰� �޼��� ===
    public void AddScore(int amount)
    {
        currentScore += amount;
    }

    public void UpDateUI(int highScore, int finalScore)
    {
        // === �ְ����� �������� �����ð� ������Ʈ ===
        TitleManager.Instance.highScore.text = highScore.ToString("N0"); // === �Ҽ��� ���� ===
        TitleManager.Instance.score.text = finalScore.ToString("N0");
        TitleManager.Instance.time.text = timer.ToString("N2");         // === �Ҽ��� ��° �ڸ����� ǥ�� ===
    }

    // === �������� ��ȯ ===
    public void FinalScore()
    {
        int finalScore = currentScore + (int)timer;

        if (finalScore >= highScore)
        {
            highScore = finalScore;
        }
        
        // === ���̽� ���Ͽ� ���� ===
        ScoreData dataToSave = new()
        {
            highScore = highScore,
            currentScore = currentScore
        };

        DataManager.Instance.Save(dataToSave);


        UpDateUI(highScore, finalScore);
    }
}
