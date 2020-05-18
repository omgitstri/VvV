using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFade : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private bool isActive = true;
    [SerializeField] private Canvas canvas;
    [SerializeField] private CanvasScaler cScaler;
    [SerializeField] private GraphicRaycaster gRay;



    void Awake() {
        //anim = GetComponent<Animator>();
        FadeIn();
        canvas = GetComponent<Canvas>();
        cScaler = GetComponent<CanvasScaler>();
        gRay = GetComponent<GraphicRaycaster>();
    }


    public void FadeIn() {
        anim.SetTrigger("FadeIn");
        StartCoroutine(ToggleCanvas());  
    }

    public void FadeOut() {
        gRay.enabled = true;

        anim.SetTrigger("FadeOut");
        StartCoroutine(ToggleCanvas());
    }

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
