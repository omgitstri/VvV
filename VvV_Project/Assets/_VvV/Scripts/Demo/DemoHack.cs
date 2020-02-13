using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoHack : MonoBehaviour
{
    [SerializeField] private Vector3 initPos = Vector3.zero;
    [SerializeField] private Vector3 currentPos = Vector3.zero;
    [SerializeField] private Transform target1 = null;
    [SerializeField] private Transform target2 = null;
    [SerializeField] private Transform weapon = null;
    private Camera mainCamera = null;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            weapon.gameObject.SetActive(false);
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;

            Physics.Raycast(ray, out raycastHit, 100);

            initPos = raycastHit.point;
            target1.position = initPos;
        }

        if (Input.GetMouseButton(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;

            Physics.Raycast(ray, out raycastHit, 100);

            currentPos = raycastHit.point;
            target2.position = currentPos;

            var scale = weapon.localScale;
            scale.y = Vector3.Distance(target1.position, target2.position) * 10;
            weapon.localScale = scale;
        }

        if (Input.GetMouseButtonUp(0))
        {
            weapon.gameObject.SetActive(true);
            var scale = weapon.localScale;
            scale.x = 1000;
            weapon.localScale = scale;

        }
    }
}
