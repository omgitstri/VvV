using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource source;

    [Header("SYSTEM SFX")]
    #region - - - - - SYSTEM SFX - - - - -

    public AudioClip menuHover;
    public AudioClip menuConfirm;
    public AudioClip menuCancel;
    public AudioClip start;
    public AudioClip pause;
    [Space]
    #endregion


    [Header("PLAYER SFX")]
    #region - - - - - PLAYER SFX - - - - - 
    public AudioClip shoot;
    public AudioClip reload;
    public AudioClip step;
    public AudioClip sprint;
    public AudioClip hurt;
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
    public AudioClip eCrawl;
    public AudioClip eRegen;
    public AudioClip eHurt;
    public AudioClip eDeath;

    public List<AudioClip> eSounds;

    [Space]
    #endregion


    [Header("EVENT SFX")]
    #region - - - - - EVENT SFX - - - - -
    public AudioClip victory;
    public AudioClip pickup;
    [Space]
    public AudioClip switchsfx;
    public AudioClip doorOpen;
    public AudioClip doorClose;
    public AudioClip destroy;
    [Space]
    public AudioClip teleportAppear;
    public AudioClip teleportIn;
    public AudioClip teleportOut;
    public AudioClip wallBreak;
    #endregion

    [Header("EMP SFX")]
    #region - - - - - EMP SFX - - - - - 
    public AudioClip empDown;
    public AudioClip empUp;
    public AudioClip empCharge;
    public AudioClip empBlast;
    #endregion



}
