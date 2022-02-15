using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("ChallengeObj Game Object")]
    public GameObject challengeObject;

    [Header("Default Spawn Delay Time")]
    public float spawnDelay = 1f;

    [Header("Default Spawn Time")]
    public float spawnTime = 2f;
    void Start()
    {
        InvokeRepeating("InstantiateObjects", spawnDelay, spawnTime);
    }

    void Update()
    {
        transform.position = new Vector3(15, -3.7f, 0);
    }

    void InstantiateObjects() {
        Instantiate(challengeObject, transform.position, transform.rotation);
    }
}
