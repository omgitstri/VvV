using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFX : MonoBehaviour
{
    public void PlaySound(AudioSource source, AudioClip sound, bool changeVP) {
        //TESTING VALUES
        if (changeVP) {
            float minMaxVol = Random.Range(0.5f, 0.80f);
            float minMaxPitch = Random.Range(0.8f, 1.25f);

        source.volume = minMaxVol;
        source.pitch = minMaxPitch;
        }


        source.clip = sound;
        source.Play();
    }
    public void StopSound(AudioSource source) {
        if (source != null && source.isPlaying)
            source.Pause();
    }

    public void LoopSound(AudioSource source, AudioClip sound) {

        if (source.clip == null || source.clip != sound) {
            source.clip = sound;
            source.Play();
        }

        else if (!source.isPlaying) {
            source.Play();
        }
    }
}
