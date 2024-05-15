//using UnityEngine;

//public class FollowCarCamera : MonoBehaviour
//{
//    public Transform target;
//    public Vector3 offset;

//    public float smoothSpeed = 0.125f;

//    void LateUpdate()
//    {
//        Vector3 localOffset = target.TransformDirection(offset);

//        Vector3 desiredPosition = target.position + localOffset;
//        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
//        transform.position = smoothedPosition;

//        transform.rotation = target.rotation;
//    }
//}


using UnityEngine;

public class FollowCarCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 thirdPersonOffset;
    public Vector3 firstPersonOffset;

    public float smoothSpeed = 0.125f;
    public Light directionalLight;
    private bool isFirstPerson = false;

    void LateUpdate()
    {
        Vector3 offset = isFirstPerson ? firstPersonOffset : thirdPersonOffset;
        Vector3 localOffset = target.TransformDirection(offset);

        Vector3 desiredPosition;
        if (isFirstPerson)
        {
            desiredPosition = target.position + localOffset;
        }
        else
        {
            desiredPosition = target.position - target.forward * offset.z + target.up * offset.y;
        }

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        if (!isFirstPerson)
        {
            transform.LookAt(target);
        }
        else
        {
            transform.rotation = target.rotation;
        }

        // Toggle between FPP and TPP when 'C' is pressed
        if (Input.GetKeyDown(KeyCode.C))
        {
            isFirstPerson = !isFirstPerson;
        }

        // Toggle directional light on/off when 'R' is pressed
        if (Input.GetKeyDown(KeyCode.R) && directionalLight != null)
        {
            directionalLight.enabled = !directionalLight.enabled;
        }

    }
}
