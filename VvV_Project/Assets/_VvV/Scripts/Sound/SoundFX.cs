using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFX : MonoBehaviour
{
    /* This script is used to change, play, stop, & loop sound effects on a single AudioSource
        To use it in a specific script, add it to a gameobject with the script that uses it and declare 
        private SoundFX sfx = null;
        sfx = GetComponent<SoundFX>();
      
        And then call the appropriate function by using sfx.FunctionName(parameters);
        Assign a source, a clip, and play the audiosource - PlaySound(AudioSource, AudioClip, Bool to change volume & pitch, minimum Volume, maximum Volume, minimum Pitch, maximum Pitch);
        Stop the audiosource - StopSound(AudioSource);
        Play a sound that needs to be looped - LoopSound(AudioSource, AudioClip, Bool to change volume & pitch, minimum Volume, maximum Volume, minimum Pitch, maximum Pitch);
        Change to a specific sound using a string - ChangeSound(String name);
        Play whatever sound is already set on it without changes - ManualPlay();
     */

    // Use of these variables is optional, if you wish to directly assign a single sound on an object, using ManualPlay();
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
            case "doorOpen":
                chosenSound = Toolbox.GetInstance.GetSound().doorOpen;
                break;
            case "doorClose":
                chosenSound = Toolbox.GetInstance.GetSound().doorClose;
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
