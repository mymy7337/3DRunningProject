using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementUI : MonoBehaviour
{
    [Header("infomation")]
    public Image achievementPanel;            // === 업적 창 ===
    public Image icon;                         // === 업적 아이콘 ===
    public TextMeshProUGUI nameText;            // === 업적 이름===
    public TextMeshProUGUI descriptionText;      // === 업적 내용 ===

    public List<AchievementData> achievements;

    private void Awake()
    {
        if (SceneLoader.Instance != null)
        {
            achievementPanel.gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        for(int i = 0; i < achievements.Count; i++)
        {
            icon.sprite = achievements[i].icon;
            nameText.text = achievements[i].achievementName;
            descriptionText.text = achievements[i].description;
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
