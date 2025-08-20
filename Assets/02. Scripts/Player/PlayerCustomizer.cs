using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerCustomizer : MonoBehaviour
{
    [SerializeField] private GameObject[] characters;

    public int characterIndex;

    public CharacterVisual characterVisual;
    public Materials materials;

    private void Awake()
    {
        var character = Instantiate(characters[characterIndex], this.transform);
        materials = character.GetComponent<Materials>();
    }

    private void Start()
    {
        if (!File.Exists(Application.persistentDataPath + "/CharacterVisual.json"))
        {
            characterVisual = new CharacterVisual();
            for (int i = 0; i < characters.Length; i++)
            {
                characterVisual.colorDatas[i] = new ColorData();
                for (int j = 0; j < materials.renderers.Length; j++)
                {
                    characterVisual.colorDatas[i].colors.Add(Color.white);
                }
            }
            Save();
        }

        SetColor();
    }

    private void SetColor()
    {
        for(int i = 0; i < materials.renderers.Length; i++)
        {
            Load();
            materials.renderers[i].material.SetColor("_Color", characterVisual.colorDatas[characterIndex].colors[i]);
        }
    }

    public void ChangeColor(int idx, Color albedo)
    {
        Material material = materials.renderers[idx].material;

        material.SetColor("_Color", albedo);

        characterVisual.colorDatas[characterIndex].colors[idx] = albedo;
        Save();
    }

    private void Save()
    {
        var saveCharacterVisual = JsonUtility.ToJson(characterVisual);

        File.WriteAllText(Application.persistentDataPath + "/CharacterVisual.json", saveCharacterVisual);
    }

    private void Load()
    {
        var loadCharacterVisual = File.ReadAllText(Application.persistentDataPath + "/CharacterVisual.json");
        characterVisual = JsonUtility.FromJson<CharacterVisual>(loadCharacterVisual);
    }

    [System.Serializable]
    public class CharacterVisual
    {
        public ColorData[] colorDatas = new ColorData[5];
    }

    [System.Serializable]
    public class ColorData
    {
        public List<Color> colors = new List<Color>();
    }
}


