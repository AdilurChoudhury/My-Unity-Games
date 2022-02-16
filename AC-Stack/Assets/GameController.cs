using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Cube Object")]
    public GameObject currentCube;

    [Header("Last Cube Object")]
    public GameObject lastCube;

    [Header("Text Object")]
    public Text text;

    [Header("Current Level")]
    public int Level;

    //Check if game is over
    [Header("Boolean")]
    public bool Done;

    void Start()
    {
        NewBlock();
    }

    // Update is called once per frame
    void Update()
    {
        if (Done) {
            return;
        }
        //Time is equal to last time since game started up
        var time = Mathf.Abs(Time.realtimeSinceStartup % 2f - 1f);
        //Pos1 refers to last cube position
        var pos1 = lastCube.transform.position + Vector3.up * 10f;
        //Pos2 refers to pos1 plus any even numbered level
        var pos2 = pos1 + ((Level % 2 == 0) ? Vector3.left : Vector3.forward) * 120;
        //For every even numbered level
        if (Level % 2 == 0) {
            currentCube.transform.position = Vector3.Lerp(pos2, pos1, time);
        } else {
            currentCube.transform.position = Vector3.Lerp(pos1, pos2, time);
        }

        if (Input.GetMouseButtonDown(0)) {
            NewBlock();
        }
        text.color = Color.HSVToRGB((Level / 100f) % 1f, 1f, 1f);
        text.text = "Level: " + Level;
    }

    void NewBlock() {

        if (lastCube != null)
        {
            currentCube.transform.position = new Vector3(Mathf.Round(currentCube.transform.position.x), currentCube.transform.position.y, Mathf.Round(currentCube.transform.position.z));

            currentCube.transform.localScale = new Vector3(lastCube.transform.localScale.x - Mathf.Abs(currentCube.transform.position.x - lastCube.transform.position.x), 
                                                        lastCube.transform.localScale.y, 
                                                        lastCube.transform.localScale.z - Mathf.Abs(currentCube.transform.position.z - lastCube.transform.position.z));
            //Current Cubes positions equal to current cube x position and last cube y position
            currentCube.transform.position = Vector3.Lerp(currentCube.transform.position, lastCube.transform.position, 0.5f) + Vector3.up * 5f;

            if (currentCube.transform.localScale.x <= 0f || currentCube.transform.localScale.z <= 0f) {
                Done = true;
            
                text.gameObject.SetActive(true);

                text.text = "Final Score: " + Level;
                StartCoroutine(X());

                return;
            }

            lastCube = currentCube;
            currentCube = Instantiate(lastCube);

            currentCube.name = Level + "";
            //Color material based on color settings
            currentCube.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.HSVToRGB((Level / 100f) % 1f, 1f, 1f));
            Level++;
            //Camera position equal to position of currentCube
            Camera.main.transform.position = currentCube.transform.position + new Vector3(100, 100, 100);

            //Camera looks at the current cube
            Camera.main.transform.LookAt(currentCube.transform.position);

        }
        
    }

    IEnumerator X() {
        //Wait three seconds then code is executed
        yield return new WaitForSeconds(3f);

        //The scene sample scene is loaded
        SceneManager.LoadScene("SampleScene");
    }
}
