using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // === 점수를 위한 타이머 ===
    private float timer;

    // === 게임내에서 현재점수, 최고점수, 이동한 거리 임의로 저장 ===
    private int highScore = 0;
    private int currentScore = 0;
    private float totalDistance = 0;

    private void Start()
    {
        // === 게임 시작시 들고옴 ===
        if (DataManager.Instance.gameData != null)
        {
            highScore = DataManager.Instance.gameData.highScore;
            totalDistance += DataManager.Instance.gameData.totalDistance;
        }

        if (TitleManager.Instance != null)
        {
            timer = 0;
        }
    }

    private void FixedUpdate()
    {
        // === 방어 코드 ===
        if (TitleManager.Instance != null)
        {
            timer += Time.fixedDeltaTime;

            totalDistance += 0.5f * Time.fixedDeltaTime;

            // === 업적 확인 ===
            if (timer >= 60.0f)
            {
                DataManager.Instance.ClearAchievement(0);
            }
            if (DataManager.Instance.jumpCount >= 99)
            {
                DataManager.Instance.ClearAchievement(2);
            }
            if(DataManager.Instance.crouchCount >= 99)
            {
                DataManager.Instance.ClearAchievement(3);
            }
            if(totalDistance >= 42195)
            {
                DataManager.Instance.ClearAchievement(4);
            }
        }
    }

    // === 점수 추가 메서드 ===
    public void AddScore(int amount)
    {
        currentScore += amount;
    }

    // === 최종점수 반환 ===
    public void FinalScore()
    {
        int finalScore = currentScore + (int)timer;

        if(finalScore >= 99)
        {
            DataManager.Instance.ClearAchievement(1);
        }

        if (finalScore >= highScore)
        {
            highScore = finalScore;
        }

        DataManager.Instance.gameData.highScore = highScore;
        DataManager.Instance.gameData.totalDistance = (int)totalDistance;

        DataManager.Instance.Save(DataManager.Instance.gameData);

        UpDateUI(highScore, finalScore);
    }

    public void UpDateUI(int highScore, int finalScore)
    {
        // === 최고점수 현재점수 생존시간 업데이트 ===
        TitleManager.Instance.highScore.text = highScore.ToString("N0"); // === 소수점 없이 ===
        TitleManager.Instance.score.text = finalScore.ToString("N0");
        TitleManager.Instance.time.text = timer.ToString("N2");         // === 소수점 둘째 자리까지 표현 ===
    }

}
