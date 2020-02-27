using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementPD : MonoBehaviour
{
    public float Speed = 70f;
    public float MouseSensitivity = 3f;

    Rigidbody rigidBody = null;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.freezeRotation = true;
    }

    private void FixedUpdate()
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (moveDirection.sqrMagnitude > 1)
            moveDirection = moveDirection.normalized;

        Vector3 targetVelocity = transform.TransformDirection(moveDirection) * Speed;

        rigidBody.AddForce(targetVelocity * Time.fixedDeltaTime, ForceMode.VelocityChange);

        float mouseDelta = 0;
        mouseDelta = Input.GetAxis("Mouse X");
        transform.Rotate(0f, mouseDelta * MouseSensitivity, 0f);
    }
}
