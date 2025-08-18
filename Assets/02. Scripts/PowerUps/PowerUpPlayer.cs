using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPlayer : MonoBehaviour
{
    private PlayerStatus playerStatus;
    private readonly Dictionary<PowerUpSO, Coroutine> running = new(); // Key: 파워업 종류; Value: 파워업의 코루틴;

    private void Awake()
    {
        playerStatus = GetComponent<PlayerStatus>();
    }

    public void Run(PowerUpSO powerUpSO)
    {
        if (powerUpSO == null) return;

        if (running.TryGetValue(powerUpSO, out var coroutine) && coroutine != null)
        {
            StopCoroutine(coroutine);
            powerUpSO.Revert(playerStatus);
        }

        running[powerUpSO] = StartCoroutine(RunCoroutine(powerUpSO));
    }

    private IEnumerator RunCoroutine(PowerUpSO powerUpSO)
    {
        powerUpSO.Apply(playerStatus);
        yield return new WaitForSeconds(powerUpSO.duration);
        powerUpSO.Revert(playerStatus);
        running.Remove(powerUpSO);
    }
}
