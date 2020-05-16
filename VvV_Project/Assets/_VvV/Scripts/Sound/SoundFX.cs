using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFX : MonoBehaviour
{
    public AudioSource chosenSource;
    public AudioClip chosenSound;
    public string soundName;

    public void PlaySound(AudioSource source, AudioClip sound, bool changeVP, float minVol, float maxVol, float minPitch, float maxPitch) {
        //TESTING VALUES
        if (changeVP) {
            float minMaxVol = Random.Range(minVol, maxVol);
            float minMaxPitch = Random.Range(minPitch, maxPitch);

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

    public void LoopSound(AudioSource source, AudioClip sound, bool changeVP, float minVol, float maxVol, float minPitch, float maxPitch) {

        if (changeVP) {
            float minMaxVol = Random.Range(minVol, maxVol);
            float minMaxPitch = Random.Range(minPitch, maxPitch);
        }
            if (source.clip == null || source.clip != sound) {
            source.clip = sound;
            source.Play();

            for (float sec=0; sec < 1f; sec += Time.deltaTime) {
                if (sec == 1f) {
                    float minMaxVol = Random.Range(minVol, maxVol);
                    float minMaxPitch = Random.Range(minPitch, maxPitch);
                    break;
                }
            }
        }



        else if (!source.isPlaying) {
            source.Play();
        }
    }

    public void ChangeSound(string soundName) {

        switch(soundName) {
            case "hover":
                chosenSound = Toolbox.GetInstance.GetSound().menuHover;
                break;
            case "confirm":
                chosenSound = Toolbox.GetInstance.GetSound().menuConfirm;
                break;
            case "cancel":
                chosenSound = Toolbox.GetInstance.GetSound().menuCancel;
                break;

        }

        if (chosenSource.clip != chosenSound) {
            chosenSource.clip = chosenSound;
        }

        ManualPlay();
    }

    public void ManualPlay() {
        if (chosenSource != null) {
            chosenSource.Play();
        }
    }
}
