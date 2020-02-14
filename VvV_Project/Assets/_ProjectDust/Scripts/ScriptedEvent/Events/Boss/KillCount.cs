using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCount : MonoBehaviour
{
    public CubeManager cubem;

    private void OnDestroy()
    {
        cubem.KillCount();
    }
}
