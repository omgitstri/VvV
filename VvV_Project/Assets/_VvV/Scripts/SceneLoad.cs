using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoad : MonoBehaviour
{
    public string sceneName;

    public void ChangeScene() {
        Toolbox.GetInstance.GetScene().LoadScene(sceneName);
    }
}
