using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTest : MonoBehaviour
{
    public AudioSource source;
    public AudioClip aClip;
    public float delay;
    public float targetVol;


    private void Start() {
        source = Toolbox.GetInstance.GetSound().GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N)) {
            Toolbox.GetInstance.GetMusic().FadeIn(aClip, targetVol);
        }

        if (Input.GetKeyDown(KeyCode.B)) {
            Toolbox.GetInstance.GetMusic().FadeOut(delay);
        }

    }
}
