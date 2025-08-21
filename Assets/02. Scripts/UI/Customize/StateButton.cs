using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateButton : MonoBehaviour
{
    public GameObject nextUI;

    public void IdleButton()
    {
        PlayerManager.Instance.Player.animationController.Idle();
        this.gameObject.SetActive(false);
        nextUI.SetActive(true);
    }

    public void RunButton()
    {
        PlayerManager.Instance.Player.animationController.Idle();
        this.gameObject.SetActive(false);
        nextUI.SetActive(true);
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
