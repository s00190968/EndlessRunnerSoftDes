using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    //Variables
    public float speed = 5;
    private float moveInput;

    //if character can be controlled manually with keyboard on false it will go forward on it's own
    public bool manualControlling = false;

    public float jumpForce = 5;
    public int maxJumps;//how many jumps can be done
    int extraJumps;//how many are left

    private Rigidbody2D rb;

    //sprite variables
    bool facingRight = true;
    float lastPosX;
    Vector3 startScale;

    //ground check
    bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask WhatIsGround;


    void Awake()
    {
        extraJumps = maxJumps;
    }

    void Start()
    {
        //rigid body
        rb = GetComponent<Rigidbody2D>();

        //object's scale at the start
        startScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        #region don't worry about this
        if (Input.GetKeyUp(KeyCode.F2))
        {
            ScreenCapture.CaptureScreenshot(DateTime.Now.ToString());
        }
        #endregion

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

        //reset extra jumps
        //check if was jumping but is now touching ground
        if(Input.GetAxis("Jump") < 1 && extraJumps <= 0 && isGrounded)
        {
            extraJumps = maxJumps;
        }

        //for manual controlling
        if (!manualControlling)
        {
            moveInput = .5f;
        }
        else
        {
            moveInput = Input.GetAxis("Horizontal");
        }

        //has to be last in update
        lastPosX = transform.position.x;
    }

    void FixedUpdate()
    {
        //cheaper to use this here also helps with sliding controls
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        //ground checks
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, WhatIsGround);

        //jumping
        if (Input.GetAxis("Jump") > 0 && extraJumps > 0)
        {
            rb.velocity = Vector3.up * jumpForce;
            extraJumps--;
        }
        else if (Input.GetAxis("Jump") > 0 && extraJumps == 0 && isGrounded)//can jump once if touching ground and extra jumps have been depleted
        {
            rb.velocity = Vector3.up * jumpForce;
        }
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
