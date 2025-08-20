using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScrollManager : MonoBehaviour
{
    public void OnScroll()
    {
        AchievementUI.Instance.NextWindowsCreate();
    }

}
