using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScoreManager : MonoBehaviour
{
    // === ������ ���� Ÿ�̸� ===
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
        // === �Ҽ��� ��° �ڸ����� ǥ�� ===
        TitleManager.Instance.score.text = timer.ToString("N2");
    }
}
