using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [Header("Move")]
    public float moveDistance;
    public float jumpPower;
    public float crouchTime;
    public float speed;
    private Vector3 moveDirection;
    private bool canMove;
    private bool isMoving;
    private bool isJumping;
    private bool canJump = true;
    private float curXPos;
    private float targetXPos;
    private float dirX;
    public LayerMask groundLayerMask;

    private float time;

    private Rigidbody _rigidbody;
    private CapsuleCollider _capsuleCollider;
    private PlayerAnimationController _animationController;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
    }
    private void Start()
    {
        _animationController = PlayerManager.Instance.Player.animationController;
    }
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (canMove)
        {
            if (!isMoving)
            {
                dirX = moveDirection.x;
                curXPos = transform.position.x;
                targetXPos = curXPos + (moveDirection.x * moveDistance);
                Quaternion delta = Quaternion.AngleAxis(30, Vector3.up * moveDirection.x);
                _rigidbody.MoveRotation(_rigidbody.rotation * delta);
                isMoving = true;
            }
            time += Time.fixedDeltaTime * speed;
            float playerXPos = Mathf.Lerp(curXPos, targetXPos, time);
            transform.position = new Vector3(playerXPos, transform.position.y, transform.position.z);
            
            if (time > 1f)
            {
                transform.position = new Vector3(targetXPos, transform.position.y, transform.position.z);
                canMove = false;
                isMoving = false;
                time = 0f;
                Quaternion delta = Quaternion.AngleAxis(30, Vector3.down * dirX);
                _rigidbody.MoveRotation(_rigidbody.rotation * delta);
                dirX = 0f;
            }
        }
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            moveDirection = context.ReadValue<Vector2>();
            canMove = true;
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            moveDirection = Vector2.zero;
        }
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started && IsGrounded() && canJump)
        {
            StartCoroutine(JumpCheck());
            _rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            _animationController.Jump();
        }
    }

    private IEnumerator JumpCheck()
    {
        isJumping = true;
        yield return new WaitForSeconds(1);
        isJumping = false;
    }

    public bool IsGrounded()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + transform.forward * 0.5f + transform.up * 0.01f, Vector3.down),
            new Ray(transform.position + -transform.forward * 0.5f + transform.up * 0.01f, Vector3.down),
            new Ray(transform.position + transform.right * 0.5f + transform.up * 0.01f, Vector3.down),
            new Ray(transform.position + -transform.right * 0.5f + transform.up * 0.01f, Vector3.down)
        };

        for (int i = 0; i < rays.Length; ++i)
        {
            if (Physics.Raycast(rays[i], 0.5f, groundLayerMask))
            {
                return true;
            }
        }

        return false;
    }

    public void OnCrouchInput(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            canJump = false;
            StartCoroutine(Crouch());
            _animationController.Crouch();
        }
    }

    private IEnumerator Crouch()
    {
        if (isJumping)
        {
            _rigidbody.AddForce(Vector3.down * jumpPower, ForceMode.Impulse);
            _animationController.Crouch();
            yield return new WaitForSeconds(0.05f);
        }

        _capsuleCollider.center = new Vector3(0, 0.6f, 0);
        _capsuleCollider.height = 1.5f;
        yield return new WaitForSeconds(1);
        _capsuleCollider.center = new Vector3(0, 1, 0);
        _capsuleCollider.height = 2.05f;
        canJump = true;
    }
}
