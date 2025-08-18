using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerCustomizer : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer[] renderers;
    //1. Çì¾î 2. ÇÇºÎ 3. ¿Ê 4. Àå°© 5. ½Å¹ß

    public ColorData colorData;

    private void Start()
    {
        SetColor();
    }

    private void SetColor()
    {
        for(int i = 0; i < renderers.Length; i++)
        {
            Load();
            renderers[i].material.SetColor("_Color", colorData.colors[i]);
        }
    }

    public void ChangeColor(int idx, Color albedo)
    {
        Material material = renderers[idx].material;

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
