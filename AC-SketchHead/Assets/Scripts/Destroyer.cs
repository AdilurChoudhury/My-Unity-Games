using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        GameObject.Find("DoodleHead").SetActive(false);
        GameObject.Find("GameController").GetComponent<GameController>().GameOver();
    }
}
