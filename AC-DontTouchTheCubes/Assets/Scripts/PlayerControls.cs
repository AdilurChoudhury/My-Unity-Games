using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    [Header("RigidBody")]
    public Rigidbody rb;
    void Start()
    {
        //Variable rigidbody equal to component rigidbody
        rb = GetComponent<Rigidbody>();

        //Game is at normal pace
        Time.timeScale = 1f;
    }

    void Update()
    {
        //Rotating the game object on the z axis
        //Multiplying the games frame rate by 7
        transform.rotation *= Quaternion.Euler(0, 0, 7 * Time.deltaTime);

        //Time scale of game
        Time.timeScale += Time.fixedDeltaTime * 0.01f;

        //Movement and rotation of camera on y axis horizontally
        rb.velocity += transform.rotation * (Vector3.right * Input.GetAxisRaw("Horizontal") * 10f * Time.deltaTime);

        //Movement and rotation of camera on y axis vertically
        rb.velocity += transform.rotation * (Vector3.up * Input.GetAxisRaw("Vertical") * 10f * Time.deltaTime);

        //Keeping camera position in bounds
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -30f, 30f), transform.position.y, Mathf.Clamp(transform.position.z, -30f, 30f));
    }

    void OnCollisionEnter(Collision collision) {
        SceneManager.LoadScene(0);
    }
}
