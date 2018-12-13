using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour {

    //New Game scene 
    public void PlayGame()
    {
        Debug.Log("YAY PLAYYYYY");


     

    }

    IEnumerator MyCoroutine()
    {
        //This is a coroutine
 

        yield return new WaitForSeconds(30f);   //Wait 25sec

        SceneManager.UnloadSceneAsync("CutScene");
        SceneManager.LoadScene("Scene");

    }


    // Use this for initialization
    void Start () {
        StartCoroutine(MyCoroutine());

    }

    // Update is called once per frame
    void Update () {
		
	}
}
