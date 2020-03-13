using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySFX : MonoBehaviour
{
    public SoundManager soundManager;


    private List<AudioSource> audioSources = new List<AudioSource>();     // [0] Movement sounds // [1] Active sounds // [2] Passive sounds

    // Start is called before the first frame update
    void Start()
    {
        soundManager = Toolbox.GetInstance().GetSound();
    }

    void Update()
    {
        // 1 = walk, 3 = run
        #region  - - - MOVEMENT AUDIO TEST CODE - - -
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            Walk();
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            Run();
        } else {
            StopSound(1);
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


    void PlaySound (int source, AudioClip sound) {

        audioSources[source].clip = soundManager.eStep;
        audioSources[source].Play();
    }

    void StopSound (int source) {
        audioSources[source].Pause();
    }

    // MOVEMENT SOUNDS FUNCTIONS - SOURCE 0
    public void Walk() { PlaySound(0, soundManager.eStep);    }
    public void Run()  { PlaySound(0, soundManager.eRun);     }
    public void Sprint() { PlaySound(0, soundManager.eSprint);}
    public void Crawl() { PlaySound(0, soundManager.eCrawl);  }


    // ACTIVE SOUNDS FUNCTIONS - SOURCE 1
    public void Attack() { PlaySound(1, soundManager.eAttack); }



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
                    break;
                }
                else if (i == audioSources.Count)
                {
                    audioSources.Add(new AudioSource());
                }
            }
        }
    }
    public void Hurt() { PlaySound(1, soundManager.eHurt); }
    public void Death() { 
        // Pause ALL Sounds
        for (int i=0; i<audioSources.Count; i++) {
            audioSources[i].Pause();
        }
        // Play DEATH CRY & CUBE DROP
        PlaySound(0, soundManager.eDeath);
        PlaySound(1, soundManager.eDrop);
    }


}
