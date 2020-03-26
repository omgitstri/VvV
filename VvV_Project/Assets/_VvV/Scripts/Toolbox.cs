using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolbox : MonoBehaviour
{

    private static Toolbox _instance = null;

    public static Toolbox GetInstance()
    {
        if (Toolbox._instance == null)
        {
            var goToolbox = new GameObject(nameof(Toolbox));
            //DontDestroyOnLoad(goToolbox);
            Toolbox._instance = goToolbox.AddComponent<Toolbox>();
        }
        return Toolbox._instance;
    }

    [SerializeField] private GameObject manager = null;
    [SerializeField] private GameObject soundManager = null;



    void Awake()
    {
        //Instantiate(soundManager, this.gameObject.transform);

        if (Toolbox._instance != null)
        {
            Destroy(this.gameObject);
        }

        //manager = GameObject.FindGameObjectWithTag("Manager");

        if (manager == null) {
            var go = new GameObject(nameof(manager));
            go.transform.parent = this.gameObject.transform;
            go.AddComponent<SceneLoader>();
            manager = go;
        
        }

        if (soundManager == null)
        {
            soundManager = Instantiate(Resources.Load(nameof(SoundManager), typeof(GameObject)) as GameObject);
            soundManager.transform.parent = this.gameObject.transform;
        }

    }

    public SceneLoader GetScene()
    {
        return manager.GetComponent<SceneLoader>();
    }

    
    public SoundManager GetSound()
    {
        return soundManager.GetComponent<SoundManager>();
    }


    public MusicManager GetMusic() {
        return soundManager.GetComponent<MusicManager>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.F1)) {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            manager.GetComponent<SceneLoader>().LoadScene("SceneLoadingGym");
        }    
    }
}