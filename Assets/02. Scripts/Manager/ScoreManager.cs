using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScoreGet
{
    int GetScore();
}

public class ScoreManager : MonoBehaviour , IScoreGet
{
    // === 점수를 위한 타이머 ===
    private float timer;

    // === 추후에 점수를 얻을 경우 ===
    [SerializeField]
    private int score = 0;

    // === 게임내에서 현재점수, 최고점수 임의로 저장 ===
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
        // === 최고점수 현재점수 생존시간 업데이트 ===
        TitleManager.Instance.highScore.text = highScore.ToString("N0"); // === 소수점 없이 ===
        TitleManager.Instance.score.text = finalScore.ToString("N0");
        TitleManager.Instance.time.text = timer.ToString("N2");         // === 소수점 둘째 자리까지 표현 ===
    }

    // === 인터페이스 구현 ===
    public int GetScore()
    {
        return score;
    }

    // === 최종점수 반환 ===
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
