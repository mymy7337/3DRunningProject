using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // === 점수를 위한 타이머 ===
    private float timer;

    private void Start()
    {
        if(GameManager.Instance != null)
        {
            timer = 0;
        }
    }

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
    }
}
