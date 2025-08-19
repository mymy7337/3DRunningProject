using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : Singleton<DataManager>
{
    private GameData gameData;

    public List<AchievementData> achievements;

    [Header("infomation")]
    public Image achievementPanel;            // === 업적 창 ===
    public Image icon;                         // === 업적 아이콘 ===
    public TextMeshProUGUI nameText;            // === 업적 이름===
    public TextMeshProUGUI descriptionText;      // === 업적 내용 ===

    private string filePath;

    protected override bool isDestroy => true;

    protected override void Awake()
    {
        base.Awake();

        // === 파일 경로를 찾기 ===
        filePath = Path.Combine(Application.persistentDataPath, "gameData.json");

        // === JSON 동기화 ===
        gameData = Load();

        // === 판넬 끄기 + 방어 코드===
        if(TitleManager.Instance != null)
        {
            achievementPanel.gameObject.SetActive(false);
        }
    }

    public void Save(GameData score)
    {

        foreach (var achievement in achievements)
        {
            score.achievements.Add(new AchievementStat
            {
                id = achievement.id,
                isClear = achievement.isClear
            });
        }

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
                highScore = 0,
                achievements = new List<AchievementStat>()
            };
            foreach (var achievement in achievements)
            {
                gameData.achievements.Add(new AchievementStat
                {
                    id = achievement.id,
                    isClear = achievement.isClear
                });
            }
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
                if(achievements[i].isClear == false && gameData.achievements[i].isClear == false)
                {
                    achievements[i].isClear = true;

                    gameData.achievements[i].isClear = achievements[i].isClear;

                    SetAchievementText(achievements[i]);

                    Save(gameData);
                }
                return;
            }
        }
    }

    // === 업적 달성시 업적창 나타내기 ===
    private void SetAchievementText(AchievementData data)
    {
        achievementPanel.gameObject.SetActive(true);

        icon.sprite = data.icon;
        nameText.text = data.achievementName;
        descriptionText.text = data.description;

        StartCoroutine(HidePanel(3.0f));
    }

    // === 업적창 끄기 ===
    private IEnumerator HidePanel(float delay)
    {
        yield return new WaitForSeconds(delay);
        achievementPanel.gameObject.SetActive(false);
    }
}
