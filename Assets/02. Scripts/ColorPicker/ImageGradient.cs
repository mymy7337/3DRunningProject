using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("UI/Effects/Simple Gradient")]
public class ImageGradient : BaseMeshEffect
{
    public Color colorA;   // 위(또는 왼쪽)
    public Color colorB = Color.black;   // 아래(또는 오른쪽)
    public bool horizontal = false;      // false=수직, true=수평

    public override void ModifyMesh(VertexHelper vh)
    {
        if (!IsActive() || vh.currentVertCount == 0) return;

        var verts = new List<UIVertex>();
        vh.GetUIVertexStream(verts);

        float min = float.MaxValue, max = float.MinValue;
        for (int i = 0; i < verts.Count; i++)
        {
            float v = horizontal ? verts[i].position.x : verts[i].position.y;
            if (v < min) min = v;
            if (v > max) max = v;
        }

        for (int i = 0; i < verts.Count; i++)
        {
            var ui = verts[i];
            float v = horizontal ? ui.position.x : ui.position.y;
            float t = Mathf.InverseLerp(min, max, v);
            ui.color = Color32.Lerp(colorB, colorA, t); // B→A로 보간
            verts[i] = ui;
        }

        vh.Clear();
        vh.AddUIVertexTriangleStream(verts);
    }
}
