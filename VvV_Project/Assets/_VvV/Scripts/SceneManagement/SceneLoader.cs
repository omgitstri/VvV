using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour {
    //Call Toolbox.GetInstance().GetScene().LoadScene(*Add scene name*); in other scripts
    public string currentScene;


    public void ReloadScene() {
        currentScene = SceneManager.GetActiveScene().name;
        Debug.Log(currentScene);
        LoadScene(currentScene);
    }

    public void LoadScene(string scene) {
        SceneManager.LoadScene(scene);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
