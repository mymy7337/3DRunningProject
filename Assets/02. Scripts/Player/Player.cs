using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController controller;
    public PlayerAnimationController animationController;
    public PlayerCustomizer customizer;

    private void Awake()
    {
        PlayerManager.Instance.Player = this;
        controller = GetComponent<PlayerController>();
        animationController = GetComponent<PlayerAnimationController>();
        customizer = GetComponent<PlayerCustomizer>();
    }
}
