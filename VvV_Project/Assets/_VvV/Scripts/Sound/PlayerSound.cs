using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour {

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

     */

    public SoundManager soundManager;
    private List<AudioSource> audioSources = new List<AudioSource>();     // [0] Movement sounds // [1] Active sounds // [2] Passive sounds
    float minMaxStart = 0f;

    void Start() {
        soundManager = Toolbox.GetInstance.GetSound();
        minMaxStart = Random.Range(0f, 5f);
    }

    void PlaySound(AudioSource source, AudioClip sound, float start) {
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

    // MOVEMENT SOUNDS FUNCTIONS - SOURCE 0
    public void Walk(AudioSource source) { PlaySound(source, soundManager.step, minMaxStart); }
    public void Sprint(AudioSource source) { PlaySound(source, soundManager.sprint, minMaxStart); }
    public void StopMove(AudioSource source) { StopSound(source); }

    // ACTIVE SOUNDS FUNCTIONS - SOURCE 1
    public void Attack(AudioSource source) { PlaySound(source, soundManager.melee, 0f); }
    public void Shoot(AudioSource source) { PlaySound(source, soundManager.shoot, 0f); }
    public void Reload(AudioSource source) { PlaySound(source, soundManager.reload, 0f); }
    public void StopAttack(AudioSource source) { StopSound(source); }

    // PASSIVE SOUNDS FUNCTIONS - SOURCE 2
    public void Hurt(AudioSource source) {
        //randomize grunts
        var hurtIndex = Random.Range(0, soundManager.hurt.Count);

        if (source != null)
            source.clip = soundManager.hurt[hurtIndex];
        PlaySound(source, source.clip, 0f);
    }

    public void Death(AudioSource source) {
        source.Pause();
        // Play DEATH CRY & CUBE DROP
        PlaySound(source, soundManager.death, 0f);
    }
    public void StopOther(AudioSource source) { StopSound(source); }

}
