using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class AchievementUI : MonoBehaviour
{
    [Header("infomation")]
    public GameObject achievementPrefabs;             // === 업적 당 나타내줄 오브젝트 ===
    public Transform parentTransform;                 // === 부모로 둘 오브젝트 ===

    private Vector3 spawnPosition = new(0, 0, 0);  // === 초기 위치 ===

    public void WindowsCreate()
    {
        foreach (Transform child in parentTransform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < DataManager.Instance.achievements.Count; i++)
        {
            GameObject newAchievement = Instantiate(achievementPrefabs, spawnPosition, Quaternion.identity);
            newAchievement.transform.SetParent(parentTransform, false);

            AchievementItem itemScript = newAchievement.GetComponent<AchievementItem>();

            if (itemScript != null)
            {
                itemScript.SetIndex(i);
            }
        }
    }

    public void OpenWindows()
    {
        DataManager.Instance.achievementPanel.gameObject.SetActive(true);
        WindowsCreate();
    }

    public void CloseWindows()
    {
        DataManager.Instance.achievementPanel.gameObject.SetActive(false);
    }
}
