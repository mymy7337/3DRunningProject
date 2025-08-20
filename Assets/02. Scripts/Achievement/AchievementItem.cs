using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementItem : MonoBehaviour
{
    public Image icon;                                // === 업적 아이콘 ===
    public TextMeshProUGUI nameText;                   // === 업적 이름===
    public TextMeshProUGUI descriptionText;             // === 업적 내용 ===
    public Image checkAchievement;                       // === 업적 클리어시 해금 ===

    public void SetIndex(int index)
    {
        AchievementData data = DataManager.Instance.achievements[index];

        icon.sprite = data.icon;
        nameText.text = data.achievementName;
        descriptionText.text = data.description;

        // === 클리어시 보여줌 ===
        if (DataManager.Instance.gameData.achievements[index].isClear == true)
        {
            checkAchievement.gameObject.SetActive(false);
        }

    }
}
