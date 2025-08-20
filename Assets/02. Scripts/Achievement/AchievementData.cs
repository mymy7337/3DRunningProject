using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Achievement", menuName = "New Achievement")]
public class AchievementData : ScriptableObject
{
    [Header("info")]
    public int id;                        // === 업적 순서 ===
    public string achievementName;         // === 업적 이름 ===
    public string description;              // === 해금 조건 ===

    [Header("etc.")]
    public Sprite icon;                       // === 업적별 아이콘 ===
}