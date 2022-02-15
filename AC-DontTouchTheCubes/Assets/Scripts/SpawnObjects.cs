using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    [Header("Spawn Cube Object")]
    public GameObject spawnCube;

    [Header("Default Difficulty")]
    public float difficulty = 40f;

    float spawn;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        spawn -= 1;
        //Random position of the cubes on the x axis and z axis
        Vector3 v3Pos = transform.position + new Vector3(Random.value * 40f - 20f, 0, Random.value * 40f - 20f);
        //Random rotation of the cubes on the x axis and z axis
        Quaternion qRotation = Quaternion.Euler(0, Random.value * 360f, Random.value * 30f);
        //Random scale of the cubes on the x axis and z axis
        GameObject createObject = Instantiate(spawnCube, v3Pos, qRotation);
        
    }
}
