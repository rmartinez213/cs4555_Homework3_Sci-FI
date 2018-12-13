using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadMenu : MonoBehaviour {


    //New Game scene 
    public void RetryGame(){
        //SceneManager.LoadScene("ENTER_GENERIC_CHECKPOINT_SCENE");
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);

        var go = new GameObject("Sacrificial Lamb");
        DontDestroyOnLoad(go);

        foreach (var root in go.scene.GetRootGameObjects())
            Destroy(root);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    //Restart Game - Starts at the very beginning (After Main Menu) 
    public void RestartGame(){
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);

        var go = new GameObject("Sacrificial Lamb");
        DontDestroyOnLoad(go);

        foreach (var root in go.scene.GetRootGameObjects())
            Destroy(root);

        SceneManager.LoadScene("Scene");
    }

    //Quit Game - Takes you to main menu
    public void QuitGame(){
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);

        var go = new GameObject("Sacrificial Lamb");
        DontDestroyOnLoad(go);

        foreach (var root in go.scene.GetRootGameObjects())
            Destroy(root);

        SceneManager.LoadScene("MainMenu");
    }
}
