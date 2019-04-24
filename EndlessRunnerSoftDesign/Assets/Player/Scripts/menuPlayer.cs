using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuPlayer : MonoBehaviour
{
    //Variables
    public float speed = 5;
    private float moveInput;

    private Rigidbody2D rb;

    //animator
    private Animator anim;

    //sprite variables
    bool facingRight = true;
    float lastPosX;
    Vector3 startScale;

    //ground check
    bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask WhatIsGround;


    void Start()
    {
        //rigid body
        rb = GetComponent<Rigidbody2D>();

        //animator
        anim = GetComponent<Animator>();

        //object's scale at the start
        startScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {

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

        moveInput = .5f;

        //update animations
        anim.SetFloat("speed", rb.velocity.x);
        anim.SetBool("isJumping", !isGrounded);

        //has to be last in update
        lastPosX = transform.position.x;
    }

    void FixedUpdate()
    {
        //cheaper to use this here also helps with sliding controls
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        //ground checks
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, WhatIsGround);
    }

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
}
