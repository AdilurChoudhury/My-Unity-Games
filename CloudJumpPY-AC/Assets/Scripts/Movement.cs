using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Movement : MonoBehaviour
{
    Rigidbody2D rigidBody;
    Animator anim;

    public float speed;

    float masterSpeed;
    bool canMoveL, canMoveR;

    public bool canJump;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        masterSpeed = speed;        
    }


    void FixedUpdate()
    {
        //get vertical velocity
        float verticalMovement = rigidBody.velocity.y;
        //if player is in the air, decrease speed
        if (Mathf.Abs(verticalMovement) >= 0.05)
        {
            canJump = false;

            speed = masterSpeed / 1.8f;

            anim.SetBool("isIdle", false);
            anim.SetBool("isJumping", true);
        }
        else
        {
            canJump = true;
            speed = masterSpeed;

            anim.SetBool("isIdle", true);
            anim.SetBool("isJumping", false); 
        }
        Debug.Log("Can Jump: " + Input.GetButton("Jump"));

        if (canJump && Input.GetButtonUp("Jump"))
        {
            rigidBody.AddForce(speed * Vector2.up, ForceMode2D.Impulse);
        }


        if (transform.position.x < -6.5f) {
            canMoveL = false;
        } else if (transform.position.x > 6.5f) {
            canMoveR = false;
        } else {
            canMoveL = true;
            canMoveR = true;
        }

        //get right/left input information
        float horizontal = Input.GetAxis("Horizontal");
        if (!canMoveL && horizontal < -0.1f) {
            transform.Translate(new Vector2(horizontal > 0 ? horizontal : 0, 0) * Time.deltaTime * speed);
        } else if (!canMoveR && horizontal > 0.1f) {
            transform.Translate(new Vector2(horizontal < 0 ? horizontal : 0, 0) * Time.deltaTime * speed);
        } else {
            //transform.position += new Vector3(horizontal, 0) * Time.deltaTime * speed; 
            transform.Translate(new Vector2(horizontal, 0) * Time.deltaTime * speed);
        } 

        
        //move player left and right according to user input and speed
    }
}

