using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{

    public static readonly int isIdling = Animator.StringToHash("IsIdle");
    public static readonly int isJumping = Animator.StringToHash("IsJump");
    public static readonly int isCrouch = Animator.StringToHash("IsCrouch");

    public Animator animator;

    public bool isIdle;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void ResetAnimator(Animator _animator)
    {
        animator = _animator;

    }

    public void Idle()
    {
        isIdle = !isIdle;
        animator.SetBool(isIdling, isIdle);
    }

    public void Jump()
    {
        if(!isIdle)
            animator.SetTrigger(isJumping);
    }

    public void Crouch()
    {
        if(!isIdle)
            animator.SetTrigger(isCrouch);
    }
}
