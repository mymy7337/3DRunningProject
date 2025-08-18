using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateButton : MonoBehaviour
{
    public void RunButton()
    {
        PlayerManager.Instance.Player.animationController.Run();
    }

    public void JumpButton()
    {
        PlayerManager.Instance.Player.animationController.Jump();
    }
    public void CrouchButton()
    {
        PlayerManager.Instance.Player.animationController.Crouch();
    }
}
