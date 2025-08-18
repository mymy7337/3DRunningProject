using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/Invincibility")]
public class InvincibilitySO : PowerUpSO
{
    public override void Apply(PlayerStatus playerStatus)
    {
        Debug.Log("Invincibility On.");
        if (playerStatus != null)
            playerStatus.SetInvincible(true);
    }

    public override void Revert(PlayerStatus playerStatus)
    {
        Debug.Log("Invincibility Off.");
        if (playerStatus != null)
            playerStatus.SetInvincible(false);
    }
}
