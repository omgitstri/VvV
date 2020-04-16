using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFX : MonoBehaviour
{

    /* - - - - - - - - INSTRUCTIONS - HOW TO USE THE CODE - - - - - - 
     
        Call the intended sound using Toolbox.GetInstance().GetSound().[FUNCTION_NAME()]

        - Walking --- Walk()
        - Sprinting - Sprint()

        - Melee ----- Attack()
        - Shooting -- Shoot()
        - Empty Clip- Empty();
        - Reloading - Reload();

        - Hurting  -- Hurt();
        - Dying ----- Death();


        - - - STOP Movement Sounds - - - 
        StopMove();

        - - - STOP Attack/Gun Sounds - - -
        StopAttack();

        - - - STOP Other Sounds - - - 
        StopOther();

     */

    public SoundManager soundManager;
    private List<AudioSource> audioSources = new List<AudioSource>();     // [0] Movement sounds // [1] Active sounds // [2] Passive sounds
    float minMaxStart = 0f;

    void Start()
    {
        soundManager = Toolbox.GetInstance.GetSound();
        minMaxStart = Random.Range(0f, 5f);
    }

    void PlaySound(int source, AudioClip sound, float start) {
        //TESTING VALUES
        float minMaxVol = Random.Range(0.20f, 0.80f);
        float minMaxPitch = Random.Range(0.75f, 1.25f);

        audioSources[source].volume = minMaxVol;
        audioSources[source].pitch = minMaxPitch;

        audioSources[source].clip = sound;
        audioSources[source].Play();
    }
    void StopSound(int source)
    {
        if (audioSources[source] != null && audioSources[source].isPlaying) 
        audioSources[source].Pause();
    }

    // MOVEMENT SOUNDS FUNCTIONS - SOURCE 0
    public void Walk()   { PlaySound(0, soundManager.step, minMaxStart);   }
    public void Sprint() { PlaySound(0, soundManager.sprint, minMaxStart); }
    public void StopMove() { StopSound(0); }

    // ACTIVE SOUNDS FUNCTIONS - SOURCE 1
    public void Attack() { PlaySound(1, soundManager.melee, 0f);  }
    public void Shoot()  { PlaySound(1, soundManager.shoot, 0f);  }
    public void Reload() { PlaySound(1, soundManager.reload, 0f); }
    public void Empty()  { PlaySound(1, soundManager.empty, 0f);  }
    public void StopAttack() { StopSound(1); }

    // PASSIVE SOUNDS FUNCTIONS - SOURCE 2
    public void Hurt()
    {
        //randomize grunts
        var hurtIndex = Random.Range(0, soundManager.hurt.Count);

        if (audioSources.Count <= 0)
        {
            for (int i = 0; i < audioSources.Count; i++)
            {
                if (!audioSources[i].isPlaying)
                {
                    audioSources[i].clip = soundManager.hurt[hurtIndex];
                    PlaySound(2, audioSources[i].clip, 0f);
                    break;
                }
                else if (i == audioSources.Count)
                {
                    audioSources.Add(new AudioSource());
                }
            }
        }
    }
    public void Death()
    {
        // Pause ALL Sounds
        for (int i = 0; i < audioSources.Count; i++)
        {
            audioSources[i].Pause();
        }
        // Play DEATH CRY & CUBE DROP
        PlaySound(0, soundManager.death, 0f);
    }
    public void StopOther() { StopSound(2); }

}
