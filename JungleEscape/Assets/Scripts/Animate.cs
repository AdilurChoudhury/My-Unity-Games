using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    Jump jump;
    void Start()
    {
        animator = GetComponent<Animator>();
        jump = GetComponent<Jump>();
    }

    // Update is called once per frame
    void Update()
    {
        if (jump.isGrounded) {
            animator.SetBool("isIdle", true);
            animator.SetBool("isJumping", false);
            animator.SetBool("isWalking", false);
            if (Input.GetAxisRaw("Vertical") == 1) {
                animator.SetBool("isWalking", true);
                animator.SetBool("isIdle", false);
                animator.SetBool("isWalkingBackwards", false);
            }
            if (Input.GetAxisRaw("Vertical") == -1) {
                //Play backwards walking animation
                animator.SetBool("isWalking", false);
                animator.SetBool("isIdle", false);
                animator.SetBool("isWalkingBackwards", true);
            }
        }
        if (!jump.isGrounded) {
            animator.SetBool("isJumping", true);
            animator.SetBool("isIdle", false);
            animator.SetBool("isWalking", false);
            animator.SetBool("isWalkingBackwards", false);
        }
    }
}
