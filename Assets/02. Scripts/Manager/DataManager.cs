using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    [SerializeField]
    private ScoreData scoreData;

    private string filePath;

    protected override bool isDestroy => false;

    protected override void Awake()
    {
        base.Awake();

        // === ���� ��θ� ã�� ===
        filePath = Path.Combine(Application.persistentDataPath, "gameData.json");
        Load();
    }

    public void Save(ScoreData score)
    {
        var saveData = JsonUtility.ToJson(score);

        File.WriteAllText(filePath, saveData);
    }

    public ScoreData Load()
    {
        // === ���� Ȯ�� �� �ε� ===
        if (File.Exists(filePath)) 
        {
            var loadData = File.ReadAllText(filePath);

            return JsonUtility.FromJson<ScoreData>(loadData);
        }
        else
        {
            // === ������ �ϳ� ������� ===
            scoreData = new ScoreData { highScore = 0, currentScore = 0 };
            string json = JsonUtility.ToJson(scoreData);
            File.WriteAllText(filePath, json);

            return scoreData;
        }
    }
}
