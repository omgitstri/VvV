using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour {

    /* Used to load scenes
     
         *** Call Toolbox.GetInstance().GetScene().LoadScene(*Add scene name*); in other scripts */

    public string currentScene;
    private AudioSource source;
    private SoundFX sfx;

    void Start() {
        source = Toolbox.GetInstance.GetSound().source;
        if (source != null) {
            sfx = source.GetComponent<SoundFX>();
        }
    }

    public void ReloadScene() {
        currentScene = SceneManager.GetActiveScene().name;
        LoadScene(currentScene);
    }

    public void LoadScene(string scene) {

        Toolbox.GetInstance.GetFade().FadeGreen();
        StartCoroutine(DelayLoad(scene));

    }

    public IEnumerator DelayLoad(string scene) {
        if (source != null && sfx != null) {
            sfx.PlaySound(source, Toolbox.GetInstance.GetSound().teleportOut, false, 1f, 1f, 1f, 1f);
        }
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(scene);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
