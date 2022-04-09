using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody2D rigidbodyPlayer;
    float jumpForce = 15;

    public bool canJump;
    void Start()
    {
        rigidbodyPlayer = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rigidbodyPlayer.velocity.y > -.01 && rigidbodyPlayer.velocity.y < .01)
        {
            canJump = true;
        } else {
            canJump = false;
        }

        if (canJump && Input.GetButtonDown("Jump")) {
            rigidbodyPlayer.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
