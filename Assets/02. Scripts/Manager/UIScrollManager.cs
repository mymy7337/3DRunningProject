using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScrollManager : MonoBehaviour
{
    public void OnScroll(Vector2 normalizedPosition)
    {
        AchievementItem.Instance.NextWindowsCreate(normalizedPosition);
    }
}
