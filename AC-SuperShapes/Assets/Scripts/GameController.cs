using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //Takes in a list of shape prefabs
    [Header("Shape Objects")]
    public GameObject[] shapePrefabs;
    
    //Spawn rate for objects
    [Header("Default Spawn Delay Time")]
    public float spawnDelay = 2f;
    
    [Header("Default Spawn Time")]
    public float spawnTime = 3f;

    [Header("Game Over UI Object")]
    public GameObject gameOverCanvas;
    void Start()
    {
        InvokeRepeating("Spawn", spawnDelay, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Spawn() {
        int randomInt = Random.Range(0, shapePrefabs.Length);
        Instantiate(shapePrefabs[randomInt], Vector3.zero, Quaternion.identity);
    }

    public void GameOver() {
        //Stops the spawn function
        CancelInvoke("Spawn");

        //Display game over screen
        gameOverCanvas.SetActive(true);

        Time.timeScale = 0;
    }
}
