using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demowaypoint : MonoBehaviour
{
    public List<Transform> positions;
    Transform currentTarget;
    int index = 0;

    private void Awake()
    {
        currentTarget = positions[index];
        pos = transform.position;

    }
    private void Start()
    {
    }
    Vector3 pos;
    float ratio = 0f;

    private void Update()
    {
        if (Vector3.Distance(currentTarget.position, transform.position) < 0.5)
        {
            if (index != positions.Count - 1)
            {
                index++;
            }
            else
            {
                index = 0;
            }
            ratio = 0;
            currentTarget = positions[index];
            pos = transform.position;
        }
        else
        {
            ratio += 0.5f * Time.deltaTime;
            transform.position = Vector3.Lerp(pos, currentTarget.position, ratio);
        }
    }
}
