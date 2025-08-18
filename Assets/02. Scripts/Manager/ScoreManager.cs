using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // === 점수를 위한 타이머 ===
    private float timer;

    // === 게임내에서 현재점수, 최고점수 임의로 저장 ===
    private int highScore = 0;
    private int currentScore = 0;

    public List<AchievementData> achievements;

    private void Start()
    {
        // === GameData에서 저장된 highScore를 불러옴 ===
        GameData loadedData = DataManager.Instance.Load();
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
        // === 방어 코드 ===
        if (TitleManager.Instance != null)
        {
            timer += Time.fixedDeltaTime;

            // === 첫번째 업적 ===
            if (timer >= 6.0f && DataManager.Instance.achievements[0].isClear == false)
            {
                DataManager.Instance.ClearAchievement(0);
            }
        }
    }

    // === 점수 추가 메서드 ===
    public void AddScore(int amount)
    {
        currentScore += amount;
    }

    public void UpDateUI(int highScore, int finalScore)
    {
        // === 최고점수 현재점수 생존시간 업데이트 ===
        TitleManager.Instance.highScore.text = highScore.ToString("N0"); // === 소수점 없이 ===
        TitleManager.Instance.score.text = finalScore.ToString("N0");
        TitleManager.Instance.time.text = timer.ToString("N2");         // === 소수점 둘째 자리까지 표현 ===
    }

    // === 최종점수 반환 ===
    public void FinalScore()
    {
        int finalScore = currentScore + (int)timer;

        if (finalScore >= highScore)
        {
            highScore = finalScore;
        }
        
        // === 제이슨 파일에 저장 ===
        GameData dataToSave = new()
        {
            highScore = highScore,
        };

        DataManager.Instance.Save(dataToSave);

        UpDateUI(highScore, finalScore);
    }
}
