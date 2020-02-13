using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targetable : MonoBehaviour
{
    void Start()
    {
        TargetManager.Instance.RegisterTarget(this.transform);
    }

    void Update()
    {
        
    }
}
