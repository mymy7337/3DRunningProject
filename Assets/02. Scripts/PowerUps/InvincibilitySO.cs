using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/Invincibility")]
public class InvincibilitySO : PowerUpSO
{
    public override void Apply(PlayerStatus playerStatus)
    {
        if (playerStatus != null)
            playerStatus.SetInvincible(true);
    }

    public override void Revert(PlayerStatus playerStatus)
    {
        if (playerStatus != null)
            playerStatus.SetInvincible(false);
    }
}
