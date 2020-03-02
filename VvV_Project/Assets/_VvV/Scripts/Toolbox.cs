using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolbox : MonoBehaviour
{

    private static Toolbox _instance;

    public static Toolbox GetInstance()
    {
        if (Toolbox._instance == null)
        {
            var goToolbox = new GameObject("Toolbox");
            //DontDestroyOnLoad(goToolbox);
            Toolbox._instance = goToolbox.AddComponent<Toolbox>();
        }
        return Toolbox._instance;
    }

    [SerializeField] private GameObject manager;
    [SerializeField] private GameObject soundManager;



    void Awake()
    {
        //Instantiate(soundManager, this.gameObject.transform);

        if (Toolbox._instance != null)
        {
            Destroy(this.gameObject);
        }

        //manager = GameObject.FindGameObjectWithTag("Manager");



        if (manager == null) {
            var go = new GameObject("Manager");
            go.transform.parent = this.gameObject.transform;

        
        }

        if (soundManager == null) {
            soundManager = Instantiate(Resources.Load("SoundManager", typeof(GameObject)) as GameObject);
            soundManager.transform.parent = this.gameObject.transform;
        }





    }


    
    public SoundManager GetSound()
    {
        return soundManager.GetComponent<SoundManager>();
    }
    
}