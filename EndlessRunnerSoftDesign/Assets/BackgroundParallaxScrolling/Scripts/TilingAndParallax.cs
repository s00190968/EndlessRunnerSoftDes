using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script should be on the background element container objects(those that have the actual bg objects as children).

public class TilingAndParallax : MonoBehaviour
{
    float backgroundSizeX;//width of background object
    Transform camTransform;//main camera's transform

    [SerializeField]
    Transform[] objects;//list of the objects to be parallaxed and tiled. Needs at least three of the same kind.

    float viewZone = 10;//the extra offset so that sems won't be seen

    [SerializeField]
    int leftIndex;//for debugging

    [SerializeField]
    int rightIndex;//for debugging

    float previousCamX;//camera's previous x position

    public float parallaxSpeedX = 2; //how fast the parallax effect is

    public bool scrolling;//should the objects be scrolled
    public bool parallax;//should the object be parallaxed

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
        if (scrolling)
        {
            backgroundSizeX = objects[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        }
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
