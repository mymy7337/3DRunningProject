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
        // === 소수점 둘째 자리까지 표현 ===
        TitleManager.Instance.score.text = FinalScore().ToString();
        TitleManager.Instance.time.text = timer.ToString("N2");
    }

    // === 인터페이스 구현 ===
    public int GetScore()
    {
        return score;
    }

    // === 최종점수 반환 ===
    public int FinalScore()
    {
        return GetScore() + (int)timer;
    }
}
