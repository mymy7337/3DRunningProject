using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCustomizer : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer[] renderers;
    //1. �Ǻ� 2. �尩 3. �Ӹ� 4. �� 5. �Ź�

    public void ChangeColor(int idx, Color albedo)
    {
        Material material = renderers[idx].material;

        material.SetColor("_Color", albedo);
    }
}
