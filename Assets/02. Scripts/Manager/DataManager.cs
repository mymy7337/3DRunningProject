using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField]
    private ScoreData scoreData;

    private string filePath = Application.persistentDataPath + "/ScoreData.json";

    // === 싱글톤 ===
    public static DataManager Instance { get; private set; }

    private void Awake()
    {
        // 싱글톤 패턴 구현
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        Load();
    }

    void Save()
    {
        var saveData = JsonUtility.ToJson(scoreData);

        File.WriteAllText(filePath, saveData);
    }

    void Load()
    {
        // === 파일 확인 후 로드 ===
        if (File.Exists(filePath)) 
        {
            var loadData = File.ReadAllText(filePath);
            scoreData = JsonUtility.FromJson<ScoreData>(loadData);
        }
        else
        {
            Debug.Log("저장된 JSON 파일이 없습니다.");
        }
    }
}
