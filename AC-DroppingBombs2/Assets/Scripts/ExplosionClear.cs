using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionClear : MonoBehaviour
{
    private ParticleSystem particleSmoke;
    private void Awake() 
    {
        particleSmoke = gameObject.GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        if (!particleSmoke.IsAlive())
        {
            Destroy(gameObject);
        }        
    }
}
