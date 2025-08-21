using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var playerStatus = other.GetComponent<PlayerStatus>();

            if (playerStatus != null && playerStatus.IsInvincible)
            {
                Debug.Log("플레이어 무적 상태, 5초간 충돌 무시됨.");
                return;
            }
        }
        TitleManager.Instance.GameOver();
        AudioManager.Instance.PlaySFX(3);
        AudioManager.Instance.SetSFXVolume(0.3f);
    }
}
