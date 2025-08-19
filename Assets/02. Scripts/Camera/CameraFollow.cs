using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Transform target;   // Player의 CameraAnchor
    [SerializeField, Min(0f)] private float distance = 8f;
    [SerializeField, Min(0f)] private float height   = 8f;

    [Header("Smoothing")]
    [SerializeField, Min(0f)] private float positionLerp = 6f;
    [SerializeField, Min(0f)] private float rotationLerp = 8f;

    [Header("Orientation")]
    [SerializeField] private bool lockTilt = true;   // 좌우 이동 중에도 회전하지 않게
    [SerializeField] private float fixedTilt = 0f;   // 직선 러너면 0 권장
    [SerializeField] private float pitchAngle = 25f; // 내려다보는 각도

    public void Bind(Transform x) => target = x;

    private void LateUpdate()
    {
        if (!target) return;

        Vector3 desiredPos = target.position
                           - Vector3.forward * distance
                           + Vector3.up      * height;

        transform.position = Vector3.Lerp(
            transform.position,
            desiredPos,
            positionLerp * Time.deltaTime
        );

        float tilt = lockTilt ? fixedTilt : target.eulerAngles.y;

        Quaternion desiredRot = Quaternion.Euler(pitchAngle, tilt, 0f);

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            desiredRot,
            rotationLerp * Time.deltaTime
        );
    }
}
