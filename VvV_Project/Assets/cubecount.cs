using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubecount : MonoBehaviour
{
    public List<IndividualCube> gos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("count")]
    private void CountCube()
    {
        gos = new List<IndividualCube>();
        gos.AddRange(GetComponentsInChildren<IndividualCube>());
    }
}
