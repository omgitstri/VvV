using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource targetAudio;
    [SerializeField] private float plusVol = 0.01f;
    [SerializeField] private float targetVolume = 1f;
    [SerializeField] private bool decrease = false;

    [Header("MUSIC SFX")]
    #region - - - - - MUSIC - - - - - 
    public AudioClip main;
    public AudioClip begin;
    public AudioClip wave;
    public AudioClip down;
    #endregion

    void Start() {
        /*
        if (targetAudio == null) {
            targetAudio = new AudioSource();
            targetAudio.loop = true;
        }*/
    }



    #region - - - - MUSIC FUNCTIONS - - - -
    public void FadeIn(float delay, float maxVol, AudioClip clip) {
        // delay is for how long the fadein takes until it reaches maximum volume
        // 

        targetAudio.clip = clip;
    }

    public void FadeOut(float delay ) {
        // delay is for how long the fadein takes until it reaches minimum volume
    }

    public void StopMusic(float delay) {

    }
    #endregion

    public void PlayMain() {

    }

    /*
    void ChangeVol() {

        // - - - DECREASING VOLUME
        if (triggered && targetAudio.volume > targetVolume && decrease)
            targetAudio.volume -= incrementVol;

        else if (decrease && targetAudio.volume < targetVolume) {
            targetAudio.volume = targetVolume;
            return;
        }


        // - - - - INCREASING VOLUME
        if (triggered && targetAudio.volume < targetVolume && !decrease)
            targetAudio.volume += incrementVol;

        else if (!decrease && targetAudio.volume > targetVolume) {
            targetAudio.volume = targetVolume;
            return;
        }

    }
    */
}
