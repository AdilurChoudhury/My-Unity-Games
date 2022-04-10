using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectFalsePlatforms : MonoBehaviour
{
    public bool hit;
    void Update()
    {
        hit = Physics.Raycast(transform.position, Vector3.forward, 3, 1 << 8);
        Debug.DrawRay(transform.position, transform.forward * 3, Color.red);
        if (hit) {
            Debug.Log("All Clear!");
        } else {
            Debug.LogWarning("Be Careful!");
        }
    }
}
