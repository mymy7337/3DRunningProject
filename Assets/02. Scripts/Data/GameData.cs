using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable] // === 저장할 이름 정의 ===
public class GameData 
{
    public int highScore;
    public float totalDistance;

    public List<AchievementStat> achievements = new();
}
