using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : Singleton<DataManager>
{
    public GameData gameData;

    public List<AchievementData> achievements;

    [Header("infomation")]
    public Image achievementPanel;            // === 업적 창 ===
    public Image icon;                         // === 업적 아이콘 ===
    public TextMeshProUGUI nameText;            // === 업적 이름===
    public TextMeshProUGUI descriptionText;      // === 업적 내용 ===

    private string filePath;

    private Coroutine _playCoroutine;             // === 업적창 중복 방지 ===

    // === 업적 확인용 ===
    [HideInInspector]
    public int jumpCount;
    [HideInInspector]
    public int crouchCount;
    [HideInInspector]
    public float totalDistance;

    protected override bool isDestroy => true;

    protected override void Awake()
    {
        base.Awake();

        // === 파일 경로를 찾기 ===
        filePath = Path.Combine(Application.persistentDataPath, "gameData.json");

        // === JSON 동기화 ===
        Load();

        // === 판넬 끄기 + 방어 코드===
        if(TitleManager.Instance != null)
        {
            achievementPanel.gameObject.SetActive(false);
        }
    }

    public void Save(GameData score)
    {
        var saveData = JsonUtility.ToJson(score);

        File.WriteAllText(filePath, saveData);
    }

    public void Load()
    {
        // === 파일 확인 후 로드 ===
        if (File.Exists(filePath))
        {
            var loadData = File.ReadAllText(filePath);

            gameData = JsonUtility.FromJson<GameData>(loadData);

            if (gameData.achievements == null)
            {
                gameData.achievements = new List<AchievementStat>();
            }

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
                    isClear = false
                });
            }
            string json = JsonUtility.ToJson(gameData);
            File.WriteAllText(filePath, json);

            Save(gameData);
        }
    }

    // === 업적 해금 ===
    public void ClearAchievement(int id)
    {
        for(int i = 0; i < achievements.Count; i++)
        {
            if(id == achievements[i].id)
            {
                if(gameData.achievements[i].isClear == false)
                {
                    gameData.achievements[i].isClear = true;

                    SetAchievementText(achievements[i]);

                    Save(gameData);
                }
            }
        }
    }

    // === 업적 달성시 업적창 나타내기 ===
    private void SetAchievementText(AchievementData data)
    {
        if (_playCoroutine != null)
        {
            StopCoroutine(_playCoroutine);
        }

        achievementPanel.gameObject.SetActive(true);

        icon.sprite = data.icon;
        nameText.text = data.achievementName;
        descriptionText.text = data.description;

        _playCoroutine = StartCoroutine(HidePanel(3.0f));
    }

    // === 업적창 끄기 ===
    private IEnumerator HidePanel(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        achievementPanel.gameObject.SetActive(false);

        _playCoroutine = null;
    }
}
