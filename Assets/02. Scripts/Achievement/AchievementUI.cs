using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class AchievementUI : MonoBehaviour
{
    public void OpenWindows()
    {
        DataManager.Instance.achievementPanel.gameObject.SetActive(true);
    }

    public void CloseWindows()
    {
        DataManager.Instance.achievementPanel.gameObject.SetActive(false);
    }
}
