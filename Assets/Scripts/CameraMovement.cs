using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;     // 따라갈 대상(플레이어)
    public float smoothSpeed = 5f; // 부드러운 이동 속도
    public Vector3 offset;         // 카메라 오프셋

    public bool followX = true;    // X축 따라갈지 여부
    public bool followY = true;    // Y축 따라갈지 여부

    void LateUpdate()
    {
        if (target == null)
            return;

        // 현재 카메라 위치
        Vector3 currentPos = transform.position;

        // 목표 위치 계산
        Vector3 targetPos = currentPos;

        if (followX)
            targetPos.x = target.position.x + offset.x;

        if (followY)
            targetPos.y = target.position.y + offset.y;

        targetPos.z = currentPos.z; // 카메라 Z는 고정

        // 부드럽게 보간
        transform.position = Vector3.Lerp(currentPos, targetPos, smoothSpeed * Time.deltaTime);
    }
}
