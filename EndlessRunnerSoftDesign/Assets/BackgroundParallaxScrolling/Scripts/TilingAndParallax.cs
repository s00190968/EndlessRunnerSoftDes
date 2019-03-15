using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script should be on the background element container objects(those that have the actual bg objects as children).

public class TilingAndParallax : MonoBehaviour
{
    float backgroundSizeX = 5;
    Transform camTransform;
    [SerializeField]
    Transform[] objects;
    float viewZone = 10;
    [SerializeField]
    int leftIndex;
    [SerializeField]
    int rightIndex;
    float previousCamX;

    public float parallaxSpeedX = 2;
    public bool scrolling;
    public bool parallax;

    private void Awake()
    {
        camTransform = Camera.main.transform;
        previousCamX = camTransform.position.x;
    }
    void Start()
    {
        previousCamX = camTransform.position.x;
        objects = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            objects[i] = transform.GetChild(i);
        }
        leftIndex = 0;
        rightIndex = objects.Length - 1;
        backgroundSizeX = objects[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x;
    }

    private void Update()
    {
        if (parallax)
        {
            float deltaX = camTransform.position.x - previousCamX;
            transform.position += Vector3.right * (deltaX * parallaxSpeedX);
        }
        previousCamX = camTransform.position.x;

        if (scrolling)
        {
            if (camTransform.position.x < (objects[leftIndex].transform.position.x + viewZone))
            {
                scrollLeft();
            }
            if (camTransform.position.x > (objects[rightIndex].transform.position.x - viewZone))
            {
                scrollRight();
            }
        }
    }

    void scrollLeft()
    {
        int previousRight = rightIndex;
        Vector3 tempV3 = Vector3.right * (objects[leftIndex].position.x - backgroundSizeX);
        objects[rightIndex].position = new Vector3(tempV3.x, objects[leftIndex].position.y, objects[leftIndex].position.z);
        leftIndex = rightIndex;
        rightIndex--;
        if (rightIndex < 0)
        {
            rightIndex = objects.Length - 1;
        }
    }

    void scrollRight()
    {
        int previousLeft = leftIndex;
        Vector3 tempV3 = Vector3.right * (objects[rightIndex].position.x + backgroundSizeX);
        objects[leftIndex].position = new Vector3(tempV3.x, objects[rightIndex].position.y, objects[rightIndex].position.z);
        rightIndex = leftIndex;
        leftIndex++;
        if (leftIndex == objects.Length)
        {
            leftIndex = 0;
        }
    }
}
