using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    //Variables
    public float Speed = 5;
    public float minSpeed = 1;
    private float moveInput;

    //if character can be controlled manually with keyboard on false it will go forward on it's own
    public bool manualControlling = false;

    public float JumpForce = 17;

    private Rigidbody2D rb;

    //sprite variables
    bool facingRight = true;
    float lastPosX;
    Vector3 startScale;

    //ground check
    [SerializeField]
    bool isGrounded;
    public Transform GroundCheck;
    public float CheckRadius;
    public LayerMask WhatIsGround;

    //animations
    PlayerAnimationManager aniMan;

    void Start()
    {
        //rigid body
        rb = GetComponent<Rigidbody2D>();

        //animation manager
        aniMan = GetComponent<PlayerAnimationManager>();

        //object's scale at the start
        startScale = transform.localScale;

        lastPosX = transform.position.x;
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

        //for manual controlling
        if (!manualControlling)
        {
            moveInput = .5f;
        }
        else
        {
            moveInput = Input.GetAxis("Horizontal");
        }

        //animations in animationmanager script
        aniMan.Speed = rb.velocity.x;
        aniMan.IsInAir = !isGrounded;

        //has to be last in update
        lastPosX = transform.position.x;
    }

    void FixedUpdate()
    {
        //cheaper to use this here also helps with sliding controls
        rb.velocity = new Vector2(moveInput * Speed, rb.velocity.y);

        //ground checks
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, CheckRadius, WhatIsGround);

        //jumping
        if (Input.GetAxis("Jump") > 0 && isGrounded)
        {
            Debug.Log("jumping");
            rb.velocity = Vector3.up * JumpForce;
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

    //speed changing
    public void IncreaseSpeed(float amount)
    {
        Speed += amount;
    }
    public void DecreaseSpeed(float amount)
    {
        Speed -= amount;

        if(Speed < minSpeed)
        {
            Speed = minSpeed;
        }
    }
}
