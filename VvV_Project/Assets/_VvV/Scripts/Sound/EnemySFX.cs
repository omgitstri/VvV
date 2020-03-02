using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySFX : MonoBehaviour
{
    public SoundManager soundManager;

    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public AudioSource audioSource3;

    // Start is called before the first frame update
    void Start()
    {
        soundManager = Toolbox.GetInstance().GetSound();
    }

    void Update()
    {

        // - - - TEST CODE - - -
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            PlayWalk();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            PlayMelee();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            PlayRun();
        }
    }


            /* - - - - - - - - CODE TEMPLATE - - - - - - - - 
            public void FunctionName() {
        
                audioSource.clip = //[soundmanagerpath].[audioClipname];
                audioSource.Play();
            } */



    // - - - TEST FUNCTIONS - - -
    void PlayWalk()
    {
        audioSource1.clip = soundManager.eStep;
        audioSource1.Play();
    }

    void PlayMelee()
    {
        audioSource2.clip = soundManager.eMelee;
        audioSource2.Play();
    }

    void PlayRun()
    {
        audioSource1.clip = soundManager.eRun;
        audioSource1.Play();
    }
}
