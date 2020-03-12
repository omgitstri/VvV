using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMPDelay : MonoBehaviour
{
    public float delay = 0f;
    public float target = 4f;
    public float multipler = 0;
    [SerializeField] private GameObject text;

    private void OnGUI()
    {
        GUI.TextField(new Rect(50, 50, 50, 50), delay.ToString());
    }

    public void StartTimer()
    {
        multipler = 1f;
    }

    public void ResetTimer()
    {
        multipler = 0f;
        delay = 0f;
    }

    private void Update()
    {
        delay += Time.deltaTime * multipler;
        if (delay >= target && TryGetComponent<Renderer>(out Renderer render))
        {
            text.SetActive(true);
            render.material.SetColor("_BaseColor", Color.green);
            multipler = 0;
            delay = 4;
        }
    }
}
