using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private float increment = 0.0167f;

    [Header("MUSIC SFX")]
    #region - - - - - MUSIC - - - - - 
    public AudioClip main = null;
    public AudioClip begin = null;
    public AudioClip wave = null;
    public AudioClip down = null;
    #endregion

    void Start() {

        if (audioSource == null) {
            audioSource = GetComponent<AudioSource>();
            audioSource.loop = true;
        }
    }

    private void Update() {

    }

    #region - - - - MUSIC FUNCTIONS - - - -
    public void FadeIn(AudioClip aClip, float targetVol) {
        float curVol = audioSource.volume;
        audioSource.clip = aClip;

        if (!audioSource.isPlaying) {
            audioSource.Play();
        }

        for (curVol = 0; curVol < targetVol; curVol += Time.fixedTime) {
            audioSource.volume += increment;
        }
        
    }

    public void FadeOut(float delay) {
        float curVol = audioSource.volume;
        for (curVol = audioSource.volume ; curVol > 0; curVol += Time.fixedTime) {
            audioSource.volume += increment;
        }

        if (audioSource.volume <= 0) {
            audioSource.Stop();
        }
    }

    public void StopMusic(float delay) {

    }
    #endregion

    public void PlayMain() {

    }
}
