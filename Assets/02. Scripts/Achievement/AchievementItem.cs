using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementItem : Singleton<AchievementItem>
{
    public Image icon;                                // === 업적 아이콘 ===
    public TextMeshProUGUI nameText;                   // === 업적 이름===
    public TextMeshProUGUI descriptionText;             // === 업적 내용 ===
    public Image checkAchievement;                       // === 업적 클리어시 해금 ===

    protected override bool isDestroy => true;        // === 싱글톤 선언 ===

    protected override void Awake()
    {
        base.Awake();
    }

    public void SetIndex(int index)
    { 
        //icon.sprite = DataManager.Instance.achievements.icon;
        //nameText.text = DataManager.Instance.achievements.achievementName;
        //descriptionText.text = DataManager.Instance.achievements.description;

        // === 클리어시 보여줌 ===
        if (DataManager.Instance.gameData.achievements[index].isClear == true)
        {
            checkAchievement.gameObject.SetActive(false);
        }

    }

    public void NextWindowsCreate(Vector2 pos)
    {
        gameObject.transform.position = pos + new Vector2(0, -1456);

        SetIndex(3);
    }
}
