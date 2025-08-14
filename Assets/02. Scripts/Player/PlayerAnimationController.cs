using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public static readonly int isJumping = Animator.StringToHash("IsJump");
    public static readonly int isCrouch = Animator.StringToHash("IsCrouch");

    Animator animator;


    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }
    
    public void Jump()
    {
        animator.SetTrigger(isJumping);
    }

    public void Crouch()
    {
        animator.SetTrigger(isCrouch);
    }
}
