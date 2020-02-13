using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looot : MonoBehaviour
{
    public int dropKey = 2;
    public GameObject key;

    private void Update()
    {
        if (dropKey <= 0)
        {
            key.SetActive(true);
            Destroy(gameObject);
        }
    }
}
