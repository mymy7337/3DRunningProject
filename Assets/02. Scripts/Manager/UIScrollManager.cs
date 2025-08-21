using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScrollManager : Singleton<UIScrollManager>
{
    [HideInInspector]
    public bool iscontact;                         // === 접촉 여부 확인 ===
    [HideInInspector]
    public Vector2 teleport;                        // === 위치 값 ===

    protected override bool isDestroy => false;

    protected override void Awake()
    {
        base.Awake();
    }

    public void OnScroll(Vector2 normalizedPosition)
    {
        iscontact = true;

        float y = normalizedPosition.y;

        teleport = new Vector2(0, y);
    }
}
