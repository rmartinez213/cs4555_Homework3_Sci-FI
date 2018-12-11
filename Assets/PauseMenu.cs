using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    //New Game scene 
    public void ResumeGame(){
        SceneManager.LoadScene("RESUME_GENERIC_SCENE");
    }

    //Continue Game Scene
    public void QuitGame(){
        SceneManager.LoadScene("MainMenu");
    }
}
