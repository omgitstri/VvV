using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntepolateTest : MonoBehaviour
{
    public Transform start, stop;
    public List<Transform> middle = new List<Transform>();
    public float a;
    [SerializeField] Vector3 radius;
    [SerializeField] List<Vector3> lerps = new List<Vector3>();


    [ContextMenu(nameof(start))]
    private void Start()
    {
        radius = (Random.insideUnitSphere * 2);
    }

    void Update()
    {
        //Vector3 lerpA;
        //lerpA = Vector3.Lerp(start.position, middle[0].position + radius, a);
        //transform.position = Vector3.Lerp(lerpA, stop.position, a);

        for (int i = 0; i < middle.Count; i++)
        {
            if (i == 0)
            {
                lerps.Clear();
                lerps.Add(Vector3.Lerp(start.position, middle[i].position + radius, a));
            }
            else
            {
                lerps.Add(Vector3.Lerp(lerps[i - 1], middle[i].position + radius, a));
            }
        }
        transform.position = Vector3.Lerp(lerps[lerps.Count - 1], stop.position, a);
    }

    private void OnValidate()
    {
        //Vector3 lerpA;
        //lerpA = Vector3.Lerp(start.position, middle[0].position + radius, a);
        //transform.position = Vector3.Lerp(lerpA, stop.position, a);
        for (int i = 0; i < middle.Count; i++)
        {
            if (i == 0)
            {
                lerps.Clear();
                lerps.Add(Vector3.Lerp(start.position, middle[i].position + radius, a));
            }
            else
            {
                lerps.Add(Vector3.Lerp(lerps[i - 1], middle[i].position + radius, a));
            }
        }
        transform.position = Vector3.Lerp(lerps[lerps.Count - 1], stop.position, a);
    }
}
