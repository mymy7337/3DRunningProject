using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScoreGet
{
    int GetScore();
}

public class ScoreManager : MonoBehaviour , IScoreGet
{
    // === ������ ���� Ÿ�̸� ===
    private float timer;

    // === ���Ŀ� ������ ���� ��� ===
    [SerializeField]
    private int score = 0;

    // === ���ӳ����� ��������, �ְ����� ���Ƿ� ���� ===
    private int highScore = 0;
    private int currentScore = 0;

    private void Start()
    {
        if (TitleManager.Instance != null)
        {
            timer = 0;
        }
    }

    private void FixedUpdate()
    {
        if (TitleManager.Instance != null)
        {
            timer += Time.fixedDeltaTime;
        }
    }

    public void UpDateUI(int highScore, int finalScore, float timer)
    {
        // === �ְ����� �������� �����ð� ������Ʈ ===
        TitleManager.Instance.highScore.text = highScore.ToString("N0"); // === �Ҽ��� ���� ===
        TitleManager.Instance.score.text = finalScore.ToString("N0");
        TitleManager.Instance.time.text = timer.ToString("N2");         // === �Ҽ��� ��° �ڸ����� ǥ�� ===
    }

    // === �������̽� ���� ===
    public int GetScore()
    {
        return score;
    }

    // === �������� ��ȯ ===
    public void FinalScore()
    {
        currentScore = GetScore();

        if (currentScore >= highScore)
        {
            highScore = currentScore;
        }

        int finalScore = currentScore + (int)timer;

        UpDateUI(highScore, finalScore, timer);
    }
}
