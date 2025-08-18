using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCustomizer : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer[] renderers;
    //1. Çì¾î 2. ÇÇºÎ 3. ¿Ê 4. Àå°© 5. ½Å¹ß

    private void Start()
    {
        SetColor();
    }

    private void SetColor()
    {
        for(int i = 0; i < renderers.Length; i++)
        {
            Color color = new Color(PlayerPrefs.GetFloat($"{i}.r"), PlayerPrefs.GetFloat($"{i}.g"), PlayerPrefs.GetFloat($"{i}.b"));
            renderers[i].material.SetColor("_Color", color);
        }
    }

    public void ChangeColor(int idx, Color albedo)
    {
        Material material = renderers[idx].material;

        material.SetColor("_Color", albedo);

        PlayerPrefs.SetFloat($"{idx}.r", albedo.r);
        PlayerPrefs.SetFloat($"{idx}.g", albedo.g);
        PlayerPrefs.SetFloat($"{idx}.b", albedo.b);
    }
}
