using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Spikes object controlling the game")]
    public GameObject spikes;
    [Header("Default Height")]
    public float height;
    void Start()
    {
        //Start function repeating every 4 seconds
        InvokeRepeating("InstantiateObjects", 1f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        //Positions for gameObjects
        transform.position = new Vector3(5, Random.Range(-height, height), 0);
    }

    void InstantiateObjects()
    {
        //Spawn object by position and rotation
        Instantiate(spikes, transform.position, transform.rotation);
    }
}
