using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;//camera target
    public float smoothSpeed = 15f;//camera's smoothing speed
    public float timeToMove;
    public float cameraMoveSpeed = 5f;
    public Vector3 cameraOffset;
    public Vector3 cameraVelocity;

    Vector3 moveCameraDistanceX = new Vector3(7f, 0f, 0f);
    Vector3 moveCameraDistanceY = new Vector3(0f, 3f, 0f);
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 desiredPosition = target.position + cameraOffset;
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref cameraVelocity, timeToMove);
        transform.position = smoothedPosition;
    }      
}
