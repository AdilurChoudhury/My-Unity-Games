using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody rigidBody;

    float jumpForce = 5.7f;
    public bool canJump;
    public bool isGrounded;
    float fallMultiplier = 1.5f;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, .15f);
        if(Input.GetButtonDown("Jump") && isGrounded){
            rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (rigidBody.velocity.y < 0) {
            rigidBody.velocity += Physics.gravity * fallMultiplier * Time.deltaTime;
        }
    }
}

