using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    [Header("RigidBody Object")]
    public Rigidbody2D rb;
    //Shrinking speed
    [Header("Default Shrinking Speed")]
    public float shrinkSpeed = 1f;

    void Start()
    {
        //Rotation of rigidbody at random range
        rb.rotation = Random.Range(0f, 520f);
        //Local scale for hexagon
        transform.localScale = Vector3.one * 10f;


    }

    void Update()
    {
        //Polygon shrink rate
        transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;
        //Destroy if too small
        if (transform.localScale.x <= .05f) {
            Destroy(gameObject);
            Score.score++;
        }
    }
}
