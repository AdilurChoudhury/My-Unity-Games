﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    
    void Start()
    {

    }

    void Update()
    {
        //Rotate object on x axis
        transform.Rotate(Vector3.forward, Time.deltaTime * 30f);
    }
}
