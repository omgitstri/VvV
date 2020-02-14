using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public Camera camera1;
    public Camera camera2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchFrom1To2()
    {
        camera1.enabled = false;
        camera2.enabled = true;
    }

    public void SwitchFrom2To1()
    {
        camera1.enabled = true;
        camera2.enabled = false;
    }
}
