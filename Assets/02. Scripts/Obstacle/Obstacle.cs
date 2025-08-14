using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public LayerMask playerLayer;

    private void OnTriggerEnter(Collider other)
    {
        // other의 레이어가 playerLayer에 포함되는지 확인
        if ((playerLayer.value & (1 << other.gameObject.layer)) != 0)
        {
            Debug.Log("플레이어 감지됨! (레이어 기반)"); //플레이어죽이기
        }
    }
}
