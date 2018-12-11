using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    //New Game scene 
    public void PlayGame(){
        SceneManager.LoadScene("Scene");
    }

    //Continue Game Scene
    public void ContinueGame(){
        SceneManager.LoadScene("ContinueScene");
    }
}
