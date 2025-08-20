using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class AchievementUI : MonoBehaviour
{
    [Header("infomation")]
    public Transform parentTransform;                 // === 부모로 둘 오브젝트 ===

    public void OpenWindows()
    {
        DataManager.Instance.achievementPanel.gameObject.SetActive(true);
    }

    public void CloseWindows()
    {
        foreach (Transform child in parentTransform)
        {
            Destroy(child.gameObject);
        }

        DataManager.Instance.achievementPanel.gameObject.SetActive(false);
    }
}
