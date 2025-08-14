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
    private float curXPos;
    private float targetXPos;
    public LayerMask groundLayerMask;

    private float time;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
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
                curXPos = transform.position.x;
                targetXPos = curXPos + (moveDirection.x * moveDistance);
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
        if(context.phase == InputActionPhase.Started && IsGrounded())
        {
            _rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
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
}
