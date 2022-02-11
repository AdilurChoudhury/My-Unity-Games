using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //Game Over Canvas that is used for the game
    [Header("Game Over UI Object for displaying Game Over Screen")]
    public GameObject gameOverCanvas;
    //Score Canvas that is used for the game
    [Header("Score UI Object for Displaying Score")]
    public GameObject scoreCanvas;
    //Spawner Object that is used for the game
    [Header("Spawner Object for spawning objects in game")]
    public GameObject spawner;
    void Start()
    {
        //Speed for game is at a playing state
        Time.timeScale = 1;
        //Score is visible
        scoreCanvas.SetActive(true);
        //Game Over Canvas is invisible
        gameOverCanvas.SetActive(false);
        //The spawner is shown in the game
        spawner.SetActive(true);
    }

    public void GameOver()
    {
        //Game Over Canvas appears
        gameOverCanvas.SetActive(true);
        //Spawner is invisible at end of game
        spawner.SetActive(false);
        //Speed of game is at stopping state
        Time.timeScale = 0;
    }
}
