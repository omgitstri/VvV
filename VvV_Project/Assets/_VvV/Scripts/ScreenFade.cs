﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFade : MonoBehaviour
{
    /* Used for fading the screen in & out with different effects
        This primarily uses an animator for its states to play the intended effect
     */

    [SerializeField] private Animator anim = null;
    private bool isActive = true;
    private Canvas canvas;
    private CanvasScaler cScaler;
    private GraphicRaycaster gRay;
    private AudioSource source;
    private SoundFX sfx;


    void Awake() {
        //anim = GetComponent<Animator>();

        canvas = GetComponent<Canvas>();
        cScaler = GetComponent<CanvasScaler>();
        gRay = GetComponent<GraphicRaycaster>();
    }

    private void Start() {
        source = Toolbox.GetInstance.GetSound().source;
        sfx = source.GetComponent<SoundFX>();
        LateStart();
    }

    private void LateStart() {
        FadeIn();
    }

    // Used to fade from black to a visible screen
    public void FadeIn() {
        if (source != null && sfx != null) {
            sfx.PlaySound(source, Toolbox.GetInstance.GetSound().teleportIn, false, 1f, 1f, 1f, 1f);
        }
        anim.SetTrigger("FadeIn");

        StartCoroutine(ToggleCanvas());  
    }

    // Used to fade from a visible to a black screen
    public void FadeOut() {
        gRay.enabled = true;

        anim.SetTrigger("FadeOut");
        StartCoroutine(ToggleCanvas());
    }

    // Used as a transitional effect when entering a teleport
    public void FadeGreen() {
        gRay.enabled = true;

        anim.SetTrigger("FadeGreen");
        StartCoroutine(ToggleCanvas());
    }

    public IEnumerator ToggleCanvas() {

        yield return new WaitForSeconds(1f);
        if (isActive) {
            //canvas.enabled = false;
            //cScaler.enabled = false;
            gRay.enabled = false;
            isActive = false;
        }

        if (!isActive) {

            isActive = true;
        }

    }

    public void ResetTriggers() {
        anim.ResetTrigger("FadeIn");
        anim.ResetTrigger("FadeOut");
        anim.ResetTrigger("FadeGreen");
    }
}
