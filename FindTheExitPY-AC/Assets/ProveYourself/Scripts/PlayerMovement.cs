using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed = 12;
    private float speed = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed += Time.deltaTime;
        speed = Mathf.Clamp(speed, 0, maxSpeed);
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 destination = new Vector3(vertical == -1 ? 0 : horizontal, 0, vertical == -1 ? 0 : 1);
        transform.Translate(destination * speed * Time.deltaTime);
    }
}
