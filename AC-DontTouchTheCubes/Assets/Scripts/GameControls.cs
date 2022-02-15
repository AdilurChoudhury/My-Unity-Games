using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControls: MonoBehaviour
{
    //Timer text object
    private Text timerText;
    //Timer counter for adding score
    private int timerCount;
    void Start()
    {
        //Game is at playing state
        Time.timeScale = 1f;

        //Executing a coroutine
        StartCoroutine(CountTime());
        //Timer text object
        timerText = GameObject.Find("Score").GetComponent<Text>();
    }

    IEnumerator CountTime() {
        //After 1 second, 1 point is added to the score and will repeat the function
        yield return new WaitForSeconds(1f);
        timerCount++;
        timerText.text = "Score: " + timerCount;
        StartCoroutine(CountTime());
    }
}
