using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerCustomizer : MonoBehaviour
{
    [SerializeField] private GameObject[] characters;

    public int characterIndex;

    public ColorData colorData;
    public Materials materials;

    private void Awake()
    {
        var character = Instantiate(characters[characterIndex], this.transform);
        materials = character.GetComponent<Materials>();
    }

    private void Start()
    {
        if (!File.Exists(Application.persistentDataPath + "/ColorData.json"))
        {
            for(int i = 0; i < materials.renderers.Length; i++)
            {
                colorData.colors[i] = new Color(1, 1, 1);
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
            materials.renderers[i].material.SetColor("_Color", colorData.colors[i]);
        }
    }

    public void ChangeColor(int idx, Color albedo)
    {
        Material material = materials.renderers[idx].material;

        material.SetColor("_Color", albedo);

        colorData.colors[idx] = albedo;
        Save();
    }

    private void Save()
    {
        var saveColorData = JsonUtility.ToJson(colorData);

        File.WriteAllText(Application.persistentDataPath + "/ColorData.json", saveColorData);
    }

    private void Load()
    {
        var loadColorData = File.ReadAllText(Application.persistentDataPath + "/ColorData.json");
        colorData = JsonUtility.FromJson<ColorData>(loadColorData);
    }

    [System.Serializable]
    public class ColorData
    {
        public Color[] colors = new Color[5];
    }
}
