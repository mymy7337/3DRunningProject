using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementItem : MonoBehaviour
{
    [Header("index")]
    public int index;                                // === 스크롤 넘버 ===

    [Header("info")]
    public Image icon;                                // === 업적 아이콘 ===
    public TextMeshProUGUI nameText;                   // === 업적 이름===
    public TextMeshProUGUI descriptionText;             // === 업적 내용 ===
    public Image checkAchievement;                       // === 업적 클리어시 해금 ===

    private void Start()
    {
        SetInformation(DataManager.Instance.achievements[index], index);
    }

    private void Update()
    {
        if(UIScrollManager.Instance.iscontact == true)
        {
            UIScrollManager.Instance.iscontact = false;

            NextWindowsCreate(UIScrollManager.Instance.teleport);
        }
    }

    // === 정보를 넣어주기 ===
    public void SetInformation(AchievementData data, int index)
    {
        icon.sprite = data.icon;
        nameText.text = data.achievementName;
        descriptionText.text = data.description;

        // === 클리어시 보여줌 ===
        if (DataManager.Instance.gameData.achievements[index].isClear == true)
        {
            checkAchievement.gameObject.SetActive(false);
        }

    }

    public void ClearInformation()
    {
        icon.sprite = null;
        nameText.text = null;
        descriptionText.text = null;
    }

    public void NextWindowsCreate(Vector2 pos)
    {
        gameObject.transform.localPosition = - pos + new Vector2(0, - 378 * 4); 

        int indexUP = index + 1;

        if (DataManager.Instance.achievements.Count >= indexUP)                   // === index 번호를 넘기지 않도록 방어 ===
        {
            ClearInformation();

            SetInformation(DataManager.Instance.achievements[indexUP], indexUP); // === 다음으로 보여줄 창의 정보 ===
        }
        else
        {
            index = 0;
        }
    }
}
