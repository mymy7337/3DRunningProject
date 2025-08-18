using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SocialPlatforms.Impl;

public class DataManager : Singleton<DataManager>
{
    [SerializeField]
    private ScoreData scoreData;

    public List<AchievementData> achievements;

    private string filePath;

    protected override bool isDestroy => false;

    protected override void Awake()
    {
        base.Awake();

        // === 파일 경로를 찾기 ===
        filePath = Path.Combine(Application.persistentDataPath, "gameData.json");

        // === JSON 동기화 ===
        scoreData = Load();

        if (scoreData.achievements == null || scoreData.achievements.Count == 0)
        {
            scoreData.achievements = new List<AchievementData>(achievements);
            Save(scoreData);
        }
    }

    public void Save(ScoreData score)
    {
        var saveData = JsonUtility.ToJson(score);

        File.WriteAllText(filePath, saveData);
    }

    public ScoreData Load()
    {
        // === 파일 확인 후 로드 ===
        if (File.Exists(filePath)) 
        {
            var loadData = File.ReadAllText(filePath);

            return JsonUtility.FromJson<ScoreData>(loadData);
        }
        else
        {
            // === 없으면 하나 만들어줌 ===
            scoreData = new ScoreData 
            { 
                highScore = 0, currentScore = 0,
                achievements = new List<AchievementData>()
            };
            string json = JsonUtility.ToJson(scoreData);
            File.WriteAllText(filePath, json);

            return scoreData;
        }
    }

    // === 업적 해금 ===
    public void ClearAchievement(int id)
    {
        for(int i = 0; i < achievements.Count; i++)
        {
            if(id == achievements[i].id)
            {
                if(achievements[i].isClear == false)
                {
                    achievements[i].isClear = true;
                    Debug.Log($"{achievements[i].name} 업적 클리어!");
                    Save(scoreData);
                }
                return;
            }
        }
    }

}
