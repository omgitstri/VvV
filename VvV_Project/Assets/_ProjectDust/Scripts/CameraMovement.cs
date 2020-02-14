using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float MouseSensitivity = 3f;
    public float limitation = 40f;

    float rotationY = 0f;

    public void FixedUpdate()
    {
        float mouseDelta = 0;
        mouseDelta = Input.GetAxis("Mouse Y");

        rotationY += mouseDelta * MouseSensitivity;
        rotationY = Mathf.Clamp(rotationY, -limitation, limitation);

        transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0f);
    }
}
