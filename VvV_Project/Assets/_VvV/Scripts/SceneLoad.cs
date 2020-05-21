using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoad : MonoBehaviour
{
    public string sceneName;

    // Put this onto a trigger & add the scene's name you wish to load to
    public void ChangeScene() {
        Toolbox.GetInstance.GetScene().LoadScene(sceneName);
    }

    /*
    public void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            Application.Quit();
        } 
    }*/
}
