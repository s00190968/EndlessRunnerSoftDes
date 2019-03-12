using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    //Variables
    [SerializeField]
    Rigidbody2D rb;
    public float jumpForce = 12;


    //movement
    float moveHorizontal;
    float moveVertical;

    //sprite variables
    bool facingRight = true;
    float lastPosX;
    Vector3 startScale;

    Animator anim;

    // Use this for initialization
    void Start()
    {
        //rigid body
        rb = GetComponent<Rigidbody2D>();

        //animator stuff
        anim = GetComponentInChildren<Animator>();
        anim.SetFloat("Speed", 0);

        if (anim == null)
        {
            Debug.Log("There is no animator set in" + this.name);
            return;
        }

        //object's scale at the start
        startScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.F2))
        {
            ScreenCapture.CaptureScreenshot(DateTime.Now.ToString());
        }

        //change the direction the sprite is facing
        if (lastPosX < transform.position.x && !facingRight)//moves right but isn't facing right
        {
            facingRight = true;
            flipSprite();
        }
        if (lastPosX > transform.position.x && facingRight)//moves left but isn't facing left
        {
            facingRight = false;
            flipSprite();
        }

        //animation
        if (Input.GetAxis("Horizontal") < 0 || Input.GetAxis("Horizontal") > 0)//if horizontal input is pressed
        {
            //anim.SetFloat("Speed", Mathf.Abs(moveHorizontal));//makes the minus into positive for the animations
        }
        if (Input.GetAxis("Vertical") < 0 || Input.GetAxis("Vertical") > 0)//if vertical input is pressed
        {
            //anim.SetFloat("Speed", Mathf.Abs(moveVertical));//makes the minus into positive for the animations
        }
        if (Input.GetAxis("Jump") < 0)
        {
            moveVertical = 5;
        }

        //has to be last in update
        lastPosX = transform.position.x;
    }

    void FixedUpdate()
    {
        //cheaper to use this here also helps with sliding controls

        rb.velocity = new Vector2(moveHorizontal * jumpForce, moveVertical * jumpForce);


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {

        }
    }

    //scale the object so that it's facing the other direction
    public void flipSprite()
    {
        if (!facingRight)
        {
            transform.localScale = new Vector3(-startScale.x, startScale.y, startScale.z);
        }
        else
        {
            transform.localScale = new Vector3(startScale.x, startScale.y, startScale.z);
        }
    }

    public void Die()
    {
        SceneManager.LoadScene(0);
    }
}
