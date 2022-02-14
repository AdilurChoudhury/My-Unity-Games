using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("Platform Object")]
    public GameObject platform;

    [Header("Game Over Canvas Object")]
    public GameObject gameOverCanvas;
    //Default position for platform
    float pos = 0;
    void Start()
    {
        for (int i = 0; i < 1000; i++) {
            SpawnPlatforms();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnPlatforms() {
        //Spawn platforms randomly on the x axis and spawn them on the y axis every 2.5
        Instantiate(platform, new Vector3(Random.value * 10 - 5f, pos, 0.5f), Quaternion.identity);
        pos += 2.5f;
    }

    public void GameOver() {
        gameOverCanvas.SetActive(true);
    }
}
