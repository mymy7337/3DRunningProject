using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var playerStatus = other.gameObject.GetComponent<PlayerStatus>();

            if (playerStatus != null && playerStatus.IsInvincible)
            {
                Debug.Log("플레이어 무적 상태, 5초간 충돌 무시됨.");
                return;
            }
        }

        Debug.Log("플레이어 감지됨."); // 플레이어죽이기(게임오버)

        TitleManager.Instance.GameOver();
    }
}
