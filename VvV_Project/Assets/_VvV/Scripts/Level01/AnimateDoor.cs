using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateDoor : MonoBehaviour
{
    private bool opened = false;
    private Vector3 positionClose = Vector3.zero;
    private Vector3 positionOpen = Vector3.zero;
    private float a = 0;
    private AudioSource source;
    private SoundFX sfx;

    private void Start()
    {
        positionClose = transform.position;
        positionOpen = transform.position;
        positionOpen.y += 6;

        source = GetComponent<AudioSource>();
        sfx = GetComponent<SoundFX>();
    }

    void Update()
    {
        if(opened)
        {
            a += Time.deltaTime * 2f;
        }
        else
        {
            a -= Time.deltaTime * 2f;
        }

        a = Mathf.Clamp(a, 0, 1);

        transform.position = Vector3.Lerp(positionClose, positionOpen, a);
    }

    public void OpenDoor()
    {
        if (!opened) {
            opened = true;
            sfx.PlaySound(source, Toolbox.GetInstance.GetSound().doorOpen, false, 1f, 1f, 1f, 1f);
        }
        
    }

    public void CloseDoor()
    {
        if (opened) {
            opened = false;
            sfx.PlaySound(source, Toolbox.GetInstance.GetSound().doorClose, false, 1f, 1f, 1f, 1f);
        }
    }
}
