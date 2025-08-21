using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.TextCore.Text;
using static CustomizeDataManager;
using static PlayerCustomizer;

public class CustomizeDataManager : Singleton<CustomizeDataManager>
{
    protected override bool isDestroy => true;

    public CharacterVisual characterVisual;
    [SerializeField] private GameObject[] characters;

    protected override void Awake()
    {
        base.Awake();

        if (!File.Exists(Application.persistentDataPath + "/CharacterVisual.json"))
        {
            characterVisual = new CharacterVisual();
            characterVisual.characterIndex = 4;
            characterVisual.characterData = new CharacterData[characters.Length];
            characterVisual.pickerData = new PickerData[characters.Length];
            for (int i = 0; i < characters.Length; i++)
            {
                characterVisual.characterData[i] = new CharacterData();
                characterVisual.pickerData[i] = new PickerData();
                if (i != 4)
                    characterVisual.characterData[i].isAqcuire = false;
                else
                    characterVisual.characterData[i].isAqcuire |= true;
                int slotCount = SlotCount(characters[i]);
                for (int j = 0; j < slotCount; j++)
                {
                    characterVisual.characterData[i].colors.Add(Color.white);
                    characterVisual.pickerData[i].barPos.Add(Vector3.zero);
                    characterVisual.pickerData[i].circlePos.Add(Vector3.zero);
                    characterVisual.pickerData[i].index = 0;
                }
            }
            Save();
        }
    }
    private int SlotCount(GameObject character)
    {
        Materials material = character.GetComponent<Materials>();
        return material.renderers.Length;
    }
    public void Save()
    {
        var saveCharacterVisual = JsonUtility.ToJson(characterVisual);

        File.WriteAllText(Application.persistentDataPath + "/CharacterVisual.json", saveCharacterVisual);
    }

    public void Load()
    {
        var loadCharacterVisual = File.ReadAllText(Application.persistentDataPath + "/CharacterVisual.json");
        characterVisual = JsonUtility.FromJson<CharacterVisual>(loadCharacterVisual);
    }

    [System.Serializable]
    public class CharacterVisual
    {
        public int characterIndex;
        public CharacterData[] characterData;
        public PickerData[] pickerData;
    }

    [System.Serializable]
    public class CharacterData
    {
        public bool isAqcuire;
        public List<Color> colors = new List<Color>();
    }

    [System.Serializable]
    public class PickerData
    {
        public int index;
        public List<Vector3> barPos = new List<Vector3>();
        public List<Vector3> circlePos = new List<Vector3>();
    }
}
