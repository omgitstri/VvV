using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualTrigger : MonoBehaviour
{
    // Dummy fix for problematic custom triggers that repeat sound effects

    SoundFX sfx = null;
    AudioSource source = null;

    private void Start() {
        sfx = GetComponent<SoundFX>();
        source = GetComponent<AudioSource>();
    }


    public void OnTriggerEnter(Collider other) {
        if (sfx != null && source != null) {
            sfx.PlaySound(source, Toolbox.GetInstance.GetSound().switchsfx, false, 1f, 1f, 1f, 1f);
        }
    }

    public void OnTriggerExit(Collider other) {
        /*if (sfx != null && source != null) {
            sfx.PlaySound(source, Toolbox.GetInstance.GetSound().doorClose, false, 1f, 1f, 1f, 1f);
        }*/
    }
}
