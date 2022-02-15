using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("Platform Object")]
    public GameObject platform;

    [Header("Fake Platform Object")]
    public GameObject fakePlatform;

    [Header("Game Over Canvas Object")]
    public GameObject gameOverCanvas;
    //Default position for platform
    float pos = 0;
    float fakePos = 5;
    void Start()
    {
        if (this.name == GameObject.Find("GameController").name) {
            for (int i = 0; i < 1000; i++) {
                SpawnPlatforms();
            }
        } else {
            for (int i = 0; i < 500; i++) {
                SpawnFakePlatforms();
            }
        }
            
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnFakePlatforms() {
        Instantiate(fakePlatform, new Vector3(Random.value * 12 - 5f, fakePos, 0.5f), Quaternion.identity);
        fakePos += 8.0f;
    }
    void SpawnPlatforms() {
        //Spawn platforms randomly on the x axis and spawn them on the y axis every 2.5
        Instantiate(platform, new Vector3(Random.value * 10 - 5f, pos, 0.5f), Quaternion.identity);
        pos += 4.0f;
    }

    public void GameOver() {
        gameOverCanvas.SetActive(true);
    }

    
}
