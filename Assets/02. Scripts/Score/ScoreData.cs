using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable] // === 저장할 이름 정의 ===
public class ScoreData 
{
    public int highScore;
    public int currentScore; // === 추후에 돈으로 변경 ===

    // === 충돌때문에 한번만 읽는 이곳에 List를 만듬 ===
    public List<AchievementData> achievements;
}
