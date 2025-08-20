using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class AchievementUI : MonoBehaviour
{
    [Header("infomation")]
    public Image achievementPanel;                    // === 업적 창 ===
    public GameObject achievementPrefabs;             // === 업적 당 나타내줄 오브젝트 ===
    public Transform parentTransform;                 // === 부모로 둘 오브젝트 ===

    private Vector3 spawnPosition = new(62, -28, 0);  // === 초기 위치 ===

    public void Awake()
    {
        achievementPanel.gameObject.SetActive(false);
    }

    public void WindowsCreate()
    {
        for (int i = 0; i < DataManager.Instance.achievements.Count; i++)
        {
            GameObject newAchievement = Instantiate(achievementPrefabs, spawnPosition, Quaternion.identity);
            newAchievement.transform.SetParent(parentTransform, false);

            spawnPosition.y -= 362;

            AchievementItem itemScript = newAchievement.GetComponent<AchievementItem>();

            if (itemScript != null)
            {
                itemScript.SetIndex(i);
            }
        }
    }

    public void OpenWindows()
    {
        achievementPanel.gameObject.SetActive(true);
    }

    public void CloseWindows()
    {
        achievementPanel.gameObject.SetActive(false);
    }
}
