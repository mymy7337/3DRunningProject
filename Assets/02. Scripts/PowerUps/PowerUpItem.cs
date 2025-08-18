using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PowerUpItem : MonoBehaviour
{
    public PowerUpSO powerUpSO;

    private void Reset()
    {
        var collider = GetComponent<Collider>();
        collider.isTrigger = true;
    }

    private void OnTriggerEner(Collider other)
    {
        if (!other.CompareTag("Plyer")) return;

        var runner = other.GetComponent<PowerUpPlayer>();
        if (runner != null && powerUpSO != null)
        {
            runner.Run(powerUpSO);
            gameObject.SetActive(false);
        }
    }
}
