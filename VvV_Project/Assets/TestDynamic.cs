using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TestDynamic : MonoBehaviour
{
    bool myEMPBool = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
            myEMPBool = false;
        if (Input.GetKey(KeyCode.Alpha2))
            myEMPBool = true;
    }


    public void ReadEMP(Toggle _toggle)
    {
        _toggle.isOn = myEMPBool;
    }
}
