using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour {
    //Call Toolbox.GetInstance().GetScene().LoadScene(*Add scene name*); in other scripts

    public void LoadScene(string scene) {
        SceneManager.LoadScene(scene);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
