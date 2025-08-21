using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/SpeedBoost")]
public class SpeedBoostSO : PowerUpSO
{
    [Min(1f)] public float multiplier = 2.0f; // 1.5배, 2배 등

    public override void Apply(PlayerStatus playerStatus)
    {
        if (MapManager.Instance == null) return;
        MapManager.Instance.AddSpeedMultiplier(this, multiplier);
    }

    public override void Revert(PlayerStatus playerStatus)
    {
        if (MapManager.Instance == null) return;
        MapManager.Instance.RemoveSpeedMultiplier(this);
    }
}