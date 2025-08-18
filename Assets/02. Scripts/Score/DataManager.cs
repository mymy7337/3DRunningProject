using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SocialPlatforms.Impl;

public class DataManager : Singleton<DataManager>
{
    private GameData gameData;

    public List<AchievementData> achievements;

    private string filePath;

    protected override bool isDestroy => false;

    protected override void Awake()
    {
        base.Awake();

        // === 파일 경로를 찾기 ===
        filePath = Path.Combine(Application.persistentDataPath, "gameData.json");

        // === JSON 동기화 ===
        gameData = Load();

        if (gameData.achievements == null || gameData.achievements.Count == 0)
        {
            gameData.achievements = new List<AchievementData>(achievements);
            Save(gameData);
        }
    }

    public void Save(GameData score)
    {
        var saveData = JsonUtility.ToJson(score);

        File.WriteAllText(filePath, saveData);
    }

    public GameData Load()
    {
        // === 파일 확인 후 로드 ===
        if (File.Exists(filePath)) 
        {
            var loadData = File.ReadAllText(filePath);

            return JsonUtility.FromJson<GameData>(loadData);
        }
        else
        {
            // === 없으면 하나 만들어줌 ===
            gameData = new GameData 
            { 
                highScore = 0, currentScore = 0,
                achievements = new List<AchievementData>()
            };
            string json = JsonUtility.ToJson(gameData);
            File.WriteAllText(filePath, json);

            return gameData;
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
                    Save(gameData);
                }
                return;
            }
        }
    }

}
