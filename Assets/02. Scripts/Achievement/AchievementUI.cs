using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class AchievementUI : Singleton<AchievementUI>
{
    [Header("infomation")]
    public GameObject achievementPrefabs;             // === 업적 당 나타내줄 오브젝트 ===
    public Transform parentTransform;                 // === 부모로 둘 오브젝트 ===

    private Vector3 spawnPosition = new(0, 0, 0);     // === 초기 위치 ===

    protected override bool isDestroy => true;        // === 싱글톤 선언 ===

    protected override void Awake()
    {
        base.Awake();
    }

    public void WindowsCreate()
    {
        foreach (Transform child in parentTransform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < 4; i++)
        {
            GameObject newAchievement = Instantiate(achievementPrefabs, spawnPosition, Quaternion.identity);
            newAchievement.transform.SetParent(parentTransform, false);

            spawnPosition += new Vector3(0, -378, 0);

            AchievementItem itemScript = newAchievement.GetComponent<AchievementItem>();

            if (itemScript != null)
            {
                itemScript.SetIndex(i);
            }
        }
    }

    public void NextWindowsCreate()
    {
        Vector3 nextSpawnPosition = new (0, -1078, 0);

        for (int i = 0; i < 2; i++)
        {
            GameObject newAchievement = Instantiate(achievementPrefabs, nextSpawnPosition, Quaternion.identity);
            newAchievement.transform.SetParent(parentTransform, false);

            AchievementItem itemScript = newAchievement.GetComponent<AchievementItem>();

            if (itemScript != null)
            {
                itemScript.SetIndex(i + 3);
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
