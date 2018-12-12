using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    //New Game scene 
    public void PlayGame(){
        Debug.Log("YAY PLAYYYYY");
        SceneManager.LoadScene("Scene");
    }

    //Continue Game Scene
    public void ContinueGame(){
        Debug.Log("There is something inside player prefs:");
        string sceneN = PlayerPrefs.GetString("sceneName");

        Debug.Log("Stored inside is the scene name " + sceneN);
        //SceneManager.LoadScene("Scene");

        if (sceneN == "Scene") {
            SceneManager.LoadScene("Scene");
        }

        if (sceneN == "Scene3") {
            SceneManager.LoadScene("Scene");
            SceneManager.LoadScene("Scene3");
        }

        if (sceneN == "Scene4") {
            SceneManager.LoadScene("Scene");
            SceneManager.LoadScene("Scene3");
            SceneManager.LoadScene("Scene4");
        }


        //SceneManager.LoadScene("ContinueScene");


    }
}
