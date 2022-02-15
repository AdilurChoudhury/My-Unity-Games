using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("ChallengeObj Game Objects")]
    public GameObject[] challengeObject;

    [Header("Default Spawn Delay Time")]
    public float spawnDelay = 4f;

    [Header("Default Spawn Time")]
    public float spawnTime = 5f;
    void Start()
    {
        InvokeRepeating("InstantiateObjects", spawnDelay, spawnTime);
    }

    void Update()
    {
        transform.position = new Vector3(15, -3.7f, 0);
    }

    void InstantiateObjects() {
        int randomSpawn = (int) Mathf.Round(Random.Range(0, challengeObject.Length - 1));
        Instantiate(challengeObject[randomSpawn], transform.position, transform.rotation);
    }
}
