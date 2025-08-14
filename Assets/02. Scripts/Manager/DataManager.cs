using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField]
    private ScoreData scoreData;

    private string filePath = Application.persistentDataPath + "/ScoreData.json";

    // === �̱��� ===
    public static DataManager Instance { get; private set; }

    private void Awake()
    {
        // �̱��� ���� ����
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
        // === ���� Ȯ�� �� �ε� ===
        if (File.Exists(filePath)) 
        {
            var loadData = File.ReadAllText(filePath);
            scoreData = JsonUtility.FromJson<ScoreData>(loadData);
        }
        else
        {
            Debug.Log("����� JSON ������ �����ϴ�.");
        }
    }
}
