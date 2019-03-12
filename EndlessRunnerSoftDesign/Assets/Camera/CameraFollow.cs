using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;//camera target

    [SerializeField]//variable is private but can be seen in the editor
    float smoothSpeed = 15f;//camera's smoothing speed

    float timeToMove = 1;
    public float cameraMoveSpeed = 5f;
    public Vector3 cameraOffset;
    public Vector3 cameraVelocity;

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + cameraOffset;
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref cameraVelocity, timeToMove);
        transform.position = smoothedPosition;
    }
}
