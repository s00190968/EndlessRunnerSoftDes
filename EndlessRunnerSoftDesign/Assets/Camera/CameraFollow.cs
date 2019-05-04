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

    float YFollowPos;

    [SerializeField]
    Vector3 cameraVelocity;//shows up on editor

    private void Start()
    {
        YFollowPos = target.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desiredPosition = new Vector3(target.position.x, YFollowPos, target.position.z) + cameraOffset;
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref cameraVelocity, timeToMove);
        transform.position = smoothedPosition;
    }
}
