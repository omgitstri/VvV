using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBobbing : MonoBehaviour
{

    [SerializeField]private Transform weaponHolder = null;
    private Vector3 weaponHolderOrigin;
    private float movementCounter;
    private float idleCounter;
    private PlayerController player;
    [Space]
    [SerializeField]private Vector3 idleSpeed;
    [SerializeField]private Vector3 movementSpeed;
    [SerializeField] private float walkMultiplier=0;
    [SerializeField] private float runMultiplier=0;
    [SerializeField] private float walkBob = 0;
    [SerializeField] private float runBob = 0;
    private Vector3 targetBobPos;

    private void Start() {
        weaponHolderOrigin = weaponHolder.localPosition;
        //weaponHolder.localPosition = weaponHolderOrigin;
        player = GetComponent<PlayerController>();

        idleSpeed = new Vector3(idleSpeed.x, idleSpeed.y, idleSpeed.z);
        movementSpeed = new Vector3(movementSpeed.x, movementSpeed.y, movementSpeed.z);
    }



    void Update() {

        if (player.aimer.enabled) {

            // Idle
            if (!player.isMoving) {
                HeadBob(idleCounter, idleSpeed.x, idleSpeed.y);
                idleCounter += Time.deltaTime;
            }

            // Run
            else if (player.isMoving && player.isRun) {
                HeadBob(movementCounter, movementSpeed.x * runMultiplier, movementSpeed.y * runMultiplier);
                movementCounter += (Time.deltaTime * runBob);
            }


            // walk
            else {
                HeadBob(movementCounter, movementSpeed.x * walkMultiplier, movementSpeed.y * walkMultiplier);
                movementCounter += (Time.deltaTime * walkBob);
            }

            weaponHolder.localPosition = Vector3.Lerp(weaponHolder.localPosition, targetBobPos, Time.deltaTime * 5f);
        }

        if (!player.aimer.enabled) {
            weaponHolder.localPosition = weaponHolderOrigin;
        }

    }

    public void HeadBob(float v_z, float x_intensity, float y_intensity) {
        
        targetBobPos = weaponHolderOrigin + new Vector3(Mathf.Cos(v_z) * x_intensity, 
                                                        Mathf.Sin(v_z * 2) * y_intensity, 
                                                        weaponHolderOrigin.z);
    }
}
