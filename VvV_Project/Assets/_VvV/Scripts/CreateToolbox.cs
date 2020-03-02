using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateToolbox : MonoBehaviour
{
    void Awake()
    {
        Toolbox.GetInstance();
        Destroy(this.gameObject);
    }

}
