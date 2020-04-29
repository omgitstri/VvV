using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateDoor : MonoBehaviour
{
    private bool opened = false;
    private Vector3 positionClose = Vector3.zero;
    private Vector3 positionOpen = Vector3.zero;
    private float a = 0;

    private void Start()
    {
        positionClose = transform.position;
        positionOpen = transform.position;
        positionOpen.y += 6;
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
        opened = true;
    }

    public void CloseDoor()
    {
        opened = false;
    }
}
