using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{

    public static readonly int isRunning = Animator.StringToHash("IsRun");
    public static readonly int isJumping = Animator.StringToHash("IsJump");
    public static readonly int isCrouch = Animator.StringToHash("IsCrouch");

    public Animator animator;

    private bool isRun;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();

    }

    public void Run()
    {
        isRun = !isRun;
        animator.SetBool(isRunning, isRun);
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
