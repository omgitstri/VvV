using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    [Header("SYSTEM SFX")]
    #region - - - - - SYSTEM SFX - - - - -

    public AudioClip menuScroll;
    public AudioClip menuConfirm;
    public AudioClip menuCancel;
    public AudioClip start;
    public AudioClip pause;
    [Space]
    #endregion


    [Header("PLAYER SFX")]
    #region - - - - - PLAYER SFX - - - - - 
    public AudioClip shoot;
    public AudioClip empty;
    public AudioClip hit;
    public AudioClip reload;
    public AudioClip step;
    public AudioClip sprint;
    public List<AudioClip> hurt;
    public AudioClip death;
    public AudioClip melee;
    //public AudioClip vault;
    [Space]
    #endregion


    [Header("ENEMY SFX")]
    #region - - - - - ENEMY SFX - - - - -
    public List<AudioClip> eGrunts;
    public AudioClip eAttack;
    public AudioClip eAggro;
    public AudioClip eStep;
    public AudioClip eRun;
    public AudioClip eSprint;
    public AudioClip eCrawl;
    public AudioClip eDrop;
    public AudioClip eHurt;
    public AudioClip eDeath;

    public List<AudioClip> eSounds;

    [Space]
    #endregion


    [Header("EVENT SFX")]
    #region - - - - - EVENT SFX - - - - -
    public AudioClip startWave;
    public AudioClip endWave;
    public AudioClip trapNormal;
    public AudioClip trapFire;
    public AudioClip trapElect;
    public AudioClip npcGrunt;
    public AudioClip pickup1;
    public AudioClip pickup2;
    public AudioClip pickup3;
    public AudioClip gameOver;
    #endregion

}
