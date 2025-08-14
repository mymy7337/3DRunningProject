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

    private void Start()
    {
        if(TitleManager.Instance != null)
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

    public void UpDateTimer()
    {
        // === �Ҽ��� ��° �ڸ����� ǥ�� ===
        TitleManager.Instance.score.text = FinalScore().ToString();
        TitleManager.Instance.time.text = timer.ToString("N2");
    }

    // === �������̽� ���� ===
    public int GetScore()
    {
        return score;
    }

    // === �������� ��ȯ ===
    public int FinalScore()
    {
        return GetScore() + (int)timer;
    }
}
