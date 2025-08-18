using UnityEngine;

public abstract class PowerUpSO : ScriptableObject
{
    [Min(0f)] public float duration = 5f; // 파워 업 지속시간

    public abstract void Apply(PlayerStatus playerStatus);
    public abstract void Revert(PlayerStatus playerStatus);
}
