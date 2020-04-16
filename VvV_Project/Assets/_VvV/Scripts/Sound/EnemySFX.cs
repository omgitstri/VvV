using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySFX : MonoBehaviour
{

    /* - - - - - - - - INSTRUCTIONS - HOW TO USE THE CODE - - - - - - 
     
        Call the intended sound using Toolbox.GetInstance().GetSound().[FUNCTION_NAME()]

        - Walking --- Walk()
        - Running --- Run()
        - Sprinting - Sprint()
        - Crawling -- Crawl()

        - Aggro ------ Aggro()
        - Attack ----- Attack()

        - Grunting -- Grunt();
        - Hurting  -- Hurt();
        - Dying ----- Death();

      
        - - - STOP Movement Sounds - - - 
        StopMove();

        - - - STOP Attack 
        StopAttack();

        - - - STOP Other Sounds - - - 
        StopOther();

     */

    public SoundManager soundManager;
    [SerializeField]private List<AudioSource> audioSources = new List<AudioSource>();     // [0] Movement sounds // [1] Active sounds // [2] Passive sounds

    float minMaxStart = 0f;


    void Start()
    {
        soundManager = Toolbox.GetInstance.GetSound();
        minMaxStart = Random.Range(0f, 5f);
    }


    // - - - - - REMINDER TO SELF: DO NOT FORGET TO DELETE THIS - - - - - 
    void Update()
    {
        // 1 = walk, 3 = run
        #region  - - - MOVEMENT AUDIO TEST CODE - - -
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            Walk();
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            Run();
        } else if (Input.GetKeyUp(KeyCode.Alpha1) || Input.GetKeyUp(KeyCode.Alpha2)) {
            StopMove();
        }
        #endregion

        // 2 = attack
        #region - - - ACTIVE AUDIO TEST CODE - - - 
        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            Attack();
        }
        #endregion

        // 3 = grunt
        #region - - - PASSIVE AUDIO TEST CODE - - - 
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Grunt();
        }
        #endregion

    }

    void PlaySound(int source, AudioClip sound, float start) {

        //TESTING VALUES
        float minMaxVol = Random.Range(0.20f, 0.80f);
        float minMaxPitch = Random.Range(0.75f, 1.25f);

        //audioSources[source].time = start;

        audioSources[source].volume = minMaxVol;
        audioSources[source].pitch = minMaxPitch;

        audioSources[source].clip = sound;
        audioSources[source].Play();
    }

    void StopSound(int source) {
        if (audioSources[source] != null && audioSources[source].isPlaying)
            audioSources[source].Pause();
    }

    // MOVEMENT SOUNDS FUNCTIONS - SOURCE 0
    public void Walk() { PlaySound(0, soundManager.eStep, minMaxStart);    }
    public void Run()   { PlaySound(0, soundManager.eRun, minMaxStart);    }
    public void Sprint(){ PlaySound(0, soundManager.eSprint, minMaxStart); }
    public void Crawl() { PlaySound(0, soundManager.eCrawl, minMaxStart);  }
    public void StopMove() { StopSound(0); }

    // ACTIVE SOUNDS FUNCTIONS - SOURCE 1
    public void Attack(){ PlaySound(1, soundManager.eAttack, 0f); }
    public void StopAttack() { StopSound(1); }
    public void Aggro() { PlaySound(1, soundManager.eAggro, 0f); }

    // PASSIVE SOUNDS FUNCTIONS - SOURCE 2
    public void Grunt()
    {
        //randomize grunts
        var gruntIndex = Random.Range(0, soundManager.eGrunts.Count);

        if (audioSources.Count <= 0)
        {
            for (int i = 0; i < audioSources.Count; i++)
            {
                if (!audioSources[i].isPlaying)
                {
                    audioSources[i].clip = soundManager.eGrunts[gruntIndex];
                    PlaySound(2, audioSources[i].clip, minMaxStart);
                    break;
                }
                else if (i == audioSources.Count)
                {
                    audioSources.Add(new AudioSource());
                }
            }
        }
    }
    public void Hurt() { PlaySound(1, soundManager.eHurt, 0F); }
    public void Death() { 
        // Pause ALL Sounds
        for (int i=0; i<audioSources.Count; i++) {
            audioSources[i].Pause();
        }
        // Play DEATH CRY & CUBE DROP
        PlaySound(0, soundManager.eDeath, 0F);
        PlaySound(1, soundManager.eDrop, 0F);
    }
    public void StopOther() { StopSound(2); }


}
