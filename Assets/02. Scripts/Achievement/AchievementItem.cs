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


    // === 인피니티 스크롤 포기 ===
    [HideInInspector]
    public bool iscontact;                                // === 접촉 여부 확인 ===
    [HideInInspector]
    public bool endContact;                                // === 마지막 생성 확인 ===
    [HideInInspector]
    public Vector2 teleport;                               // === 위치 값 ===

    private void Start()
    {
        SetInformation(DataManager.Instance.achievements[index], index);
    }

    private void Update()
    {
        teleport.y = transform.position.y;

        if (teleport.y > 550)
        {
            iscontact = true;
        }

        if (iscontact == true)
        {
            NextWindowsCreate();
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

    // === 다음 정보를 비교 ===
    public void ClearInformation()
    {
        icon.sprite = null;
        nameText.text = null;
        descriptionText.text = null;
        checkAchievement.gameObject.SetActive(true);
    }

    public void NextWindowsCreate()
    {
        gameObject.transform.localPosition = new Vector2(0, -378 * (5 + index)); 

        int indexUP = index + 5;

        if (DataManager.Instance.achievements.Count - 1 >= indexUP)               // === index 번호를 넘기지 않도록 방어 ===
        {
            ClearInformation();

            SetInformation(DataManager.Instance.achievements[indexUP], indexUP);  // === 다음으로 보여줄 창의 정보 ===

            iscontact = false;
        }
        else
        {
            indexUP = Math.Abs(DataManager.Instance.achievements.Count - indexUP); // === 총 갯수 - 초과한 값 ===

            ClearInformation();

            SetInformation(DataManager.Instance.achievements[indexUP], indexUP);  // === 처음으로 ===

            iscontact = false;
        }
    }
}
