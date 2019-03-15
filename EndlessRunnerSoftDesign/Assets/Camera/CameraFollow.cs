using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//test comment because of github
public class CameraFollow : MonoBehaviour
{
    public Transform target;//camera target

    public float timeToMove = .1f; // how fast the camera moves after the player
    public float cameraMoveSpeed = 30f;
    public Vector3 cameraOffset;

    [SerializeField]
    Vector3 cameraVelocity;//shows up on editor

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + cameraOffset;
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref cameraVelocity, timeToMove);
        transform.position = smoothedPosition;
    }
}
