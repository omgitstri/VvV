using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFX : MonoBehaviour
{
    void PlaySound(AudioSource source, AudioClip sound) {
        //TESTING VALUES
        float minMaxVol = Random.Range(0.20f, 0.80f);
        float minMaxPitch = Random.Range(0.75f, 1.25f);

        source.volume = minMaxVol;
        source.pitch = minMaxPitch;

        source.clip = sound;
        source.Play();
    }
    void StopSound(AudioSource source) {
        if (source != null && source.isPlaying)
            source.Pause();
    }
}
