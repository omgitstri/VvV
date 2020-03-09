using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GymEnemy_PlayerFollowMouse : MonoBehaviour
{
    [SerializeField] private Camera mainCamera = null;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        Physics.Raycast(ray, out hit);

        if (hit.point != Vector3.zero)
        {
            transform.position = hit.point;
        }
    }
}
