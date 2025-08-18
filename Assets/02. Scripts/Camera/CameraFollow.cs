using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Transform target; // CameraAnchor 에 연결
    [SerializeField] private float distance = 8f;
    [SerializeField] private float height = 8f;
    [SerializeField] private float rotationLerp = 8f;

    [Header("Camera Tuning")]
    [SerializeField, Min(0f)] private float lerp = 6f;
    [SerializeField] private bool lookTarget = true;
    [SerializeField] private Vector3 lookAhead = new Vector3(0f, 1f, 6f);

    [Header("Lock Axis")]
    public bool lockZAxis = true;
    public float fixedZAxis = 0f;

    public void Bind(Transform x) => target = x;

    private void LateUpdate()
    {
        if (!target) return;

        Vector3 forward = target.forward;
        Vector3 up = target.up;
        Vector3 desiredPosition = target.position - forward * distance + up * height;
        if (lockZAxis)
            desiredPosition.z = fixedZAxis;

        transform.position = Vector3.Lerp(transform.position, desiredPosition, lerp * Time.deltaTime);

        if (lookTarget)
        {
            Quaternion desiredRotation = Quaternion.LookRotation(forward, Vector3.up);
            Vector3 euler = desiredRotation.eulerAngles;
            euler.x += 30f;
            desiredRotation = Quaternion.Euler(euler);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                desiredRotation,
                rotationLerp * Time.deltaTime
            );
        }
    }
}
