using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // === ������ ���� Ÿ�̸� ===
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
