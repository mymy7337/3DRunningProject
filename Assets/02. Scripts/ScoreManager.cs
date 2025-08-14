using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScoreManager : MonoBehaviour
{
    // === 점수를 위한 타이머 ===
    private float timer;

    private void Start()
    {
        if(TitleManager.Instance != null)
        {
            timer = 0;
        }
    }

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
    }

    public void UpDateTimer()
    {
        // === 소수점 둘째 자리까지 표현 ===
        TitleManager.Instance.score.text = timer.ToString("N2");
    }
}
