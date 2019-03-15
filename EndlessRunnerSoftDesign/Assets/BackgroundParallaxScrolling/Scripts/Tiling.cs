/*
 * This script was also made following a tutorial on Youtube by Brackeys (15/3/2019).
 * links:
 * https://youtu.be/CwGjwnjmg2w
 * https://youtu.be/77zdOaUGguc
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this should only be used with sprite renderer attached
[RequireComponent (typeof(SpriteRenderer))]
public class Tiling : MonoBehaviour
{
    public int offsetX = 2; //offset so that we don't see the seams

    //if there are elements on the right or left
    public bool hasItemOnRight;
    public bool hasItemOnLeft;

    public bool reverseScale = false;//if sprite isn't tilable

    float spriteWidth = 0f;//width of the sprite
    Camera cam;//main camera
    Transform myTransform;//the object's own transform

    void Awake()
    {
        cam = Camera.main;
        myTransform = transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteWidth = spriteRenderer.sprite.bounds.size.x;
    }

    void Update()
    {
        //are there items on left or right of this one
        if (!hasItemOnLeft || !hasItemOnRight)
        {
            //calculate the camera's extend (half the width) of what the camera can see in world coordinates
            float camHorizontalExtend = cam.orthographicSize * Screen.width / Screen.height;

            //calculate the x position where the camera sees the sprite's/element's edge 
            float edgeVisiblePosRight = (myTransform.position.x + spriteWidth / 2) - camHorizontalExtend;
            float edgeVisiblePosLeft = (myTransform.position.x - spriteWidth / 2) + camHorizontalExtend;

            //check if we can see the edge
            if (cam.transform.position.x >= edgeVisiblePosRight - offsetX && !hasItemOnRight)
            {
                MakeNewElement(1);
                hasItemOnRight = true;
            }
            else if (cam.transform.position.x <= edgeVisiblePosLeft + offsetX && !hasItemOnLeft)
            {
                MakeNewElement(-1);
                hasItemOnLeft = true;
            }
        }
    }

    //creates a new element/item on to the side required
    void MakeNewElement (int rightOrLeft)
    {
        //position for the new element
        Vector3 newPos = new Vector3(myTransform.position.x + spriteWidth * rightOrLeft, myTransform.position.y, myTransform.position.z);

        //makes a new element (instantiating is very heavy so replace with something better later) and store it in a variable
        Transform newItem = (Transform)Instantiate(myTransform, newPos, myTransform.rotation);

        if (reverseScale)
        {
            newItem.localScale = new Vector3(newItem.localScale.x * -1, newItem.localScale.y, newItem.localScale.x);//flips the sprite around so that there won't be visible seams
        }

        //new item's parent to current item's parent
        newItem.parent = myTransform.parent;

        if (rightOrLeft < 0)
        {
            newItem.GetComponent<Tiling>().hasItemOnLeft = true;
        }
        else
        {
            newItem.GetComponent<Tiling>().hasItemOnRight = true;
        }
    }
}
