using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PowerUpItem : MonoBehaviour
{
    [SerializeField] private PowerUpSO powerUpSO;
    [SerializeField] private float pickupCooldown = 0.5f; 

    private Collider _col;

    private void Awake()
    {
        _col = GetComponent<Collider>();
    }

    private void Reset()
    {
        var collider = GetComponent<Collider>();
        collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player") || !_col.enabled) return;

        var runner = other.GetComponent<PowerUpPlayer>();
        if (runner != null && powerUpSO != null)
        {
            runner.Run(powerUpSO);
            StartCoroutine(Cooldown());
        }
    }

    private IEnumerator Cooldown()
    {
        _col.enabled = false;                           
        yield return new WaitForSeconds(pickupCooldown);  
        _col.enabled = true;                               
    }
}