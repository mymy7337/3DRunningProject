using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCustomizer : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer[] renderers;
    //1. ««∫Œ 2. ¿Â∞© 3. ∏”∏Æ 4. ø  5. Ω≈πﬂ

    public void ChangeColor(int idx, Color albedo)
    {
        Material material = renderers[idx].material;

        material.SetColor("_Color", albedo);
    }
}
