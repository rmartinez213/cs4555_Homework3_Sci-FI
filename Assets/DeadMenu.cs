using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadMenu : MonoBehaviour {


    //New Game scene 
    public void RetryGame(){
        SceneManager.LoadScene("ENTER_GENERIC_CHECKPOINT_SCENE");
    }


    //Restart Game - Starts at the very beginning (After Main Menu) 
    public void RestartGame(){
        SceneManager.LoadScene("Scene");
    }

    //Quit Game - Takes you to main menu
    public void QuitGame(){
        SceneManager.LoadScene("MainMenu");
    }
}
