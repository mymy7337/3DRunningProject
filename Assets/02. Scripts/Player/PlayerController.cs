using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

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

    private float time;

    public Transform player;
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
                curXPos = player.position.x;
                targetXPos = curXPos + (moveDirection.x * moveDistance);
                isMoving = true;
            }
            time += Time.fixedDeltaTime * speed;
            float playerXPos = Mathf.Lerp(curXPos, targetXPos, time);
            player.position = new Vector3(playerXPos, player.position.y, player.position.z);

            if (time > 1f)
            {
                player.position = new Vector3(targetXPos, player.position.y, player.position.z);
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
}
