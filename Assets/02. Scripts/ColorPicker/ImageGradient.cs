using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("UI/Effects/Simple Gradient")]
public class ImageGradient : BaseMeshEffect
{
    public Color colorA;   // ��(�Ǵ� ����)
    public Color colorB = Color.black;   // �Ʒ�(�Ǵ� ������)
    public bool horizontal = false;      // false=����, true=����

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
            ui.color = Color32.Lerp(colorB, colorA, t); // B��A�� ����
            verts[i] = ui;
        }

        vh.Clear();
        vh.AddUIVertexTriangleStream(verts);
    }
}
