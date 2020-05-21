using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MusicState {none, main, begin, wave, climax, end}

public class MusicContainer : MonoBehaviour
{
    /*
        A container to control music being played on the scene
     */

    public AudioSource source;
    public AudioClip audioClip;
    public float targetVol;
    public MusicState state;
    public bool m_Play = false;


    private void Start() {
        source = Toolbox.GetInstance.GetSound().GetComponent<AudioSource>();
        ChangeState();
    }

    // Update is called once per frame
    void Update()
    {
            ChangeState();

        if (!m_Play) {
            if (source.isPlaying) {
                Toolbox.GetInstance.GetMusic().FadeOut(0f);
            }
        }

        if (m_Play) {
            if (!source.isPlaying) {
                Toolbox.GetInstance.GetMusic().FadeIn(audioClip, targetVol);
            }
        }
    }

    public void ChangeState() {
        switch(state) {
            case MusicState.none:
                audioClip = null;
                break;
            case MusicState.main:
                audioClip = Toolbox.GetInstance.GetMusic().main;
                break;
            case MusicState.begin:
                audioClip = Toolbox.GetInstance.GetMusic().begin;
                break;
            case MusicState.wave:
                audioClip = Toolbox.GetInstance.GetMusic().wave;
                break;
            case MusicState.climax:
                audioClip = Toolbox.GetInstance.GetMusic().climax;
                break;
            case MusicState.end:
                audioClip = Toolbox.GetInstance.GetMusic().end;
                break;
        }
    }

}
