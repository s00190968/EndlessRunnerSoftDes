/*
 * This script was made using the parallaxing tutorial by Brackeys on Youtube (15th of March 2019).
 * link: https://youtu.be/5E5_Fquw7BM
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour
{    
    private float[] parallaxScales;//proportion of camera's movement to move the backgrounds by
    private Transform cam; //main camera's transform
    private Vector3 prevCamPos; //camera's position in the previous frame

    public Transform[] backgrounds;//array of all the back- and foreground object to be parallaxed
    public float smoothing = 1f; //how smooth the parallax is going to be, but this has to be more than 0

    // is called before Start()
    void Awake()
    {
        //camera reference
        cam = Camera.main.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        //previus camera position at the very start
        prevCamPos = cam.position;

        parallaxScales = new float[backgrounds.Length];

        //go through all the scales and background elements
        //scales are set to be equal to the corresponding element's position on z-axis * -1
        for(int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //go through all elements in backgrounds
        for (int i = 0;i<backgrounds.Length; i++)
        {
            //parallaxing goes to the opposite direction from camera's movement
            //previous frame multiplied by the scale
            float parallax = (prevCamPos.x - cam.position.x) * parallaxScales[i];

            //set target's x position. It will be the current position plus the parallax amount
            float bgTargetXPos = backgrounds[i].position.x + parallax;

            //target position, which is the backgrounds current position with its target x position
            Vector3 bgTargetPos = new Vector3(bgTargetXPos, backgrounds[i].position.y, backgrounds[i].position.z);

            //fade between current pos and target pos using lerp
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, bgTargetPos, smoothing*Time.deltaTime);
        }

        //cameras previous position to the position of camera at the end of the frame
        prevCamPos = cam.position;
    }
}
