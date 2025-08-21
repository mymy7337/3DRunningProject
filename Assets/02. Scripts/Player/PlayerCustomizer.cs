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

    private GameObject character;

    private void Awake()
    {
        if (!File.Exists(Application.persistentDataPath + "/CharacterVisual.json"))
        {
            characterVisual = new CharacterVisual();
            characterVisual.characterIndex = 4;
            characterVisual.colorDatas = new ColorData[characters.Length];
            for (int i = 0; i < characters.Length; i++)
            {
                characterVisual.colorDatas[i] = new ColorData();
                int slotCount = SlotCount(characters[i]);
                for (int j = 0; j < slotCount; j++)
                {
                    characterVisual.colorDatas[i].colors.Add(Color.white);
                }
            }
            Save();
        }
        Load();

        character = Instantiate(characters[characterVisual.characterIndex], this.transform);
        materials = character.GetComponent<Materials>();
        SetColor();
    }

    private int SlotCount(GameObject character)
    {
        Materials material = character.GetComponent<Materials>();
        return material.renderers.Length;
    }

    public void ChangerCharacter(int characterIndex)
    {
        Destroy(character);
        character = Instantiate(characters[characterIndex], this.transform);
        materials = character.GetComponent<Materials>();
        characterVisual.characterIndex = characterIndex;
        Save();
        SetColor();
    }

    private void SetColor()
    {
        for(int i = 0; i < materials.renderers.Length; i++)
        {
            Load();
            materials.renderers[i].material.SetColor("_Color", characterVisual.colorDatas[characterVisual.characterIndex].colors[i]);
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
        Debug.Log(Application.persistentDataPath + "/CharacterVisual.json");
    }

    private void Load()
    {
        var loadCharacterVisual = File.ReadAllText(Application.persistentDataPath + "/CharacterVisual.json");
        characterVisual = JsonUtility.FromJson<CharacterVisual>(loadCharacterVisual);
    }

    [System.Serializable]
    public class CharacterVisual
    {
        public int characterIndex;
        public ColorData[] colorDatas;
    }

    [System.Serializable]
    public class ColorData
    {
        public List<Color> colors = new List<Color>();
    }
}


