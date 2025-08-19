using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementItem : MonoBehaviour
{
    [SerializeField] public Image icon;                                // === 업적 아이콘 ===
    [SerializeField] public TextMeshProUGUI nameText;                  // === 업적 이름===
    [SerializeField] public TextMeshProUGUI descriptionText;           // === 업적 내용 ===

    public void SetIndex(int index)
    {
        AchievementData data = AchievementUI.Instance.achievements[index];

        icon.sprite = data.icon;
        nameText.text = data.achievementName;
        descriptionText.text = data.description;
    }
}
