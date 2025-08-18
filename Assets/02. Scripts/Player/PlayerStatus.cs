using UnityEngine;
using System;

public class PlayerStatus : MonoBehaviour
{
    public bool IsInvincible { get; private set; }

    public event Action OnInvincibleStart;
    public event Action OnInvincibleEnd;

    public void SetInvincible(bool isInvincible)
    {
        if (IsInvincible == isInvincible) return;
        IsInvincible = isInvincible;
        if (isInvincible) OnInvincibleStart?.Invoke();
        else OnInvincibleEnd?.Invoke();
    }
}
