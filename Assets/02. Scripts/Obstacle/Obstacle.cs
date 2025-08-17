using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("플레이어 감지됨!"); //플레이어죽이기(게임오버)
            Time.timeScale = 0f;
            //게임오버 UI 띄우기
        }
    }
}
