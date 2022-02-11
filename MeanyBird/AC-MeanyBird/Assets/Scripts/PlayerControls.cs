﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    // Start is called before the first frame update
    //Game manager object
    [Header("Game Controller Object for controlling the game")]
    public GameController gameController;
    [Header("Default Velocity")]
    public float velocity = 5;
    //Physics for the bird
    private Rigidbody2D rb;
    //height of the bird object on the y axis
    private float objectHeight;

    private Rigidbody2D birdSprite;

    void Start()
    {
        //Game Controller component
        gameController = GetComponent<GameController>();
        //Speed for the game at a playing state
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody2D>();
        //Object Height equals the size of the height of the sprite
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;    
    }

    // Update is called once per frame
    void Update()
    {
        //If the left mouse button is clicked
        if (Input.GetMouseButtonDown(0)) {
            //The bird will float up on the Y axis and float back down on Y axis
            rb.velocity = Vector2.up * velocity;
        }
        OutOfBounds();
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "HighSpike" || collision.gameObject.tag == "LowSpike") {
            GameObject.Find("GameController").GetComponent<GameController>().GameOver();
        }
    } 
    private void OutOfBounds()
    {
        birdSprite = GameObject.Find("Bird").GetComponent<Rigidbody2D>();
        if (birdSprite.position.y <= -8) {
            GameObject.Find("GameController").GetComponent<GameController>().GameOver();
        }
    }
}
