using UnityEngine;

public class FollowCarCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        Vector3 localOffset = target.TransformDirection(offset);

        Vector3 desiredPosition = target.position + localOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.rotation = target.rotation;
    }
}
