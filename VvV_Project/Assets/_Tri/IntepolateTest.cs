using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntepolateTest : MonoBehaviour
{
    public Transform start, middle, stop;
    public float a;
    Vector3 radius;

    [ContextMenu(nameof(start))]
    private void Start()
    {
        radius = (Random.insideUnitSphere * 2);
    }

    void Update()
    {
        Vector3 lerpA;
        lerpA = Vector3.Lerp(start.position, middle.position + radius, a);
        transform.position = Vector3.Lerp(lerpA, stop.position, a);
    }

    private void OnValidate()
    {
        Vector3 lerpA;
        lerpA = Vector3.Lerp(start.position, middle.position + radius, a);
        transform.position = Vector3.Lerp(lerpA, stop.position, a);
    }
}
