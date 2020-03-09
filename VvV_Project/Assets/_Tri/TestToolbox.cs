using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestToolbox : MonoBehaviour
{
    ToolboxTri go;
    // Start is called before the first frame update
    void Start()
    {
            go = new  GameObject("").AddComponent<ToolboxTri>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //go.Timer();
            Debug.Log(go.InterpolateValue(3));
            //go.StartCoroutine(go.Timer(Repeat, 1));
        }
    }
    public void Begin()
    {
        Debug.Log("Start");
    }

    public void Repeat()
    {
        Debug.Log("Repeat");
    }

    public void End()
    {
        Debug.Log("End");
    }
}
