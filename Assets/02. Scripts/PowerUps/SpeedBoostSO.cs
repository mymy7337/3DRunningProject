using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/SpeedBoost")]
public class SpeedBoostSO : PowerUpSO
{
    [Min(1f)] public float multiplier = 2.0f; // 1.5배, 2배 등

    public override void Apply(PlayerStatus playerStatus)
    {
        Debug.Log("SpeedBoost");
        if (MapManager.Instance == null) return;
        // 이 SO 에셋 자신을 key로 사용 → 같은 종류 재먹기 시 갱신/리셋 동작에 유리
        MapManager.Instance.AddSpeedMultiplier(this, multiplier);
    }

    public override void Revert(PlayerStatus playerStatus)
    {
        Debug.Log("SpeedBoost off.");
        if (MapManager.Instance == null) return;
        MapManager.Instance.RemoveSpeedMultiplier(this);
    }
}