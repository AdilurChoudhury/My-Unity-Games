using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
    //Rigidbody to be stored
    [Header("RigidBody")]
    public Rigidbody2D rb;
    //Default falling speed
    [Header("Default Down Speed")]
    public float downSpeed = 20f;
    //Movement speed of sprite
    [Header("Default Movement Speed")]
    public float movementSpeed = 10f;
    //Movement direction
    [Header("Default Directional Movement Speed")]
    public float movement = 0f;

    [Header("Score Text")]
    public Text scoreText;

    //Score of the game
    private float topScore = 0.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal") * movementSpeed;
        if(movement < 0) {
            //Object faces to the left
            this.GetComponent<SpriteRenderer>().flipX = false;
        } else {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }

        if (rb.velocity.y > 0 && transform.position.y > topScore) {
            topScore = transform.position.y;
        }
        scoreText.text = "Score: " + Mathf.Round(topScore).ToString(); 
    }

    void FixedUpdate() {
        //Vector2 is 2D vector of (x, y)
        // equals the velocity of the rigidbody2D
        Vector2 velocity = rb.velocity;

        //x value of velocity determines left and right movement
        velocity.x = movement;

        //Take velocity object and set to rigidbody2D velocity
        rb.velocity = velocity;
    }

    //Collision Function
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.velocity = new Vector3(rb.velocity.x, downSpeed, 0);
    }
}
