using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHorizontalAxis : MonoBehaviour
{
    [SerializeField] private bool invertX = false;
    [SerializeField] private float speed = 5f;

    void Update()
    {
        var mouseY = Input.GetAxis("Mouse X");

        if (invertX)
        {
            mouseY *= -1;
        }

        var rot = transform.rotation;

        rot.y += mouseY * Time.deltaTime;
        transform.rotation = rot;
    }
}
