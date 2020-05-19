using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBobbing : MonoBehaviour
{

    [SerializeField]private Transform weaponHolder;
    private Vector3 weaponHolderOrigin;
    private float movementCounter;
    private float idleCounter;
    private PlayerController player;
    [Space]
    [SerializeField]private Vector3 idleSpeed;
    [SerializeField]private Vector3 movementSpeed;
    private Vector3 targetBobPos;

    private void Start() {
        weaponHolderOrigin = weaponHolder.localPosition;
        player = GetComponent<PlayerController>();

        idleSpeed = new Vector3(idleCounter, idleSpeed.y, idleSpeed.z);
        movementSpeed = new Vector3(movementCounter, movementSpeed.y, movementSpeed.z);
    }


    /*
    void Update() {

        
        if (!player.isMoving) {
            HeadBob(idleCounter, idleSpeed.x, idleSpeed.y);
            idleCounter += Time.deltaTime;
        }

        else if (player.isMoving && player.isRun) {
            HeadBob(movementCounter, movementSpeed.x * 2, movementSpeed.y * 2);
            movementCounter += Time.deltaTime * 2.5f;
        }

        else {
            HeadBob(movementCounter, movementSpeed.x, movementSpeed.y);
            movementCounter += Time.deltaTime * 2f;
        }

        weaponHolder.localPosition = Vector3.Lerp(weaponHolder.localPosition, targetBobPos, Time.deltaTime * 8f);

    } */

    public void HeadBob(float v_z, float x_intensity, float y_intensity) {
        targetBobPos = weaponHolderOrigin + new Vector3(Mathf.Cos(v_z * 2) * x_intensity, Mathf.Sin(v_z * 2) * y_intensity,  0f);
    }
}
