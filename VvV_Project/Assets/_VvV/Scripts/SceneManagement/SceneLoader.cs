using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour {
    //Call Toolbox.GetInstance().GetScene().LoadScene(*Add scene name*); in other scripts
    public string currentScene;


    public void ReloadScene() {
        currentScene = SceneManager.GetActiveScene().name;
        //Toolbox.GetInstance.GetFade().FadeOut();
        LoadScene(currentScene);

    }

    public void LoadScene(string scene) {

        Toolbox.GetInstance.GetFade().FadeGreen();
        Toolbox.GetInstance.GetFade().ResetTriggers();
        StartCoroutine(DelayLoad(scene));

    }

    public IEnumerator DelayLoad(string scene) {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(scene);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
