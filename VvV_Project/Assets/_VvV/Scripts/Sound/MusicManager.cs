using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum mState { inactive, active }

public class MusicManager : MonoBehaviour
{
    private AudioSource audioSource;
    private float targetVol = 1;
    float targetDelay;
    public bool fadeIn = false;
    public bool fadeOut = false;
    public mState state;


    [Header("MUSIC SFX")]
    #region - - - - - MUSIC - - - - - 
    public AudioClip main = null;
    public AudioClip begin = null;
    public AudioClip wave = null;
    public AudioClip end = null;
    #endregion

    void Start() {

        if (audioSource == null) {
            audioSource = GetComponent<AudioSource>();
            audioSource.loop = true;
        }
    }

    private void Update() {
        if (fadeIn && state == mState.active) {
            audioSource.volume += 0.001f;

            if (audioSource.volume >= targetVol) {
                audioSource.volume = targetVol;
                state = mState.inactive;
            }
        }


        if (fadeOut && state == mState.active) {
            audioSource.volume -= 0.001f;
            if (audioSource.volume <= 0f) {
                audioSource.Stop();
                audioSource.volume = targetVol;
                state = mState.inactive;
            }
        } 
    }

    #region - - - - MUSIC FUNCTIONS - - - -
    public void FadeIn(AudioClip audioClip, float vol) {
        audioSource.clip = audioClip;
        audioSource.Play();

        state = mState.active;
        targetVol = vol;
        fadeIn = true;
        fadeOut = false;
        Debug.Log("Activating FadeIn");

    }

    public void FadeOut(float vol) {

        targetVol = 0f;
        state = mState.active;
        fadeIn = false;
        fadeOut = true;
        Debug.Log("Activating FadeOut");

    }
    #endregion
}
