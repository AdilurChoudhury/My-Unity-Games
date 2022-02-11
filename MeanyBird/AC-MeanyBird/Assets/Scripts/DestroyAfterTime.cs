using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [Header("Default Destruct Time")]
    public float timeToDestruct;
    void Start()
    {
        //Execute DestroyObject function based on timeToDestruct
        Invoke("DestroyObject", timeToDestruct);
    }

    void Update()
    {

    }

    void DestroyObject() {
        //Destroy Object
        Destroy(gameObject);
    }
}

