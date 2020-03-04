using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableRandomDelay : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemies = new List<GameObject>();
    bool toggle = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (toggle)
            {
                foreach (var item in enemies)
                {
                    item.SetActive(false);
                }
                toggle = false;
            }
            else
            {
                foreach (var item in enemies)
                {
                    item.SetActive(true);
                }
                toggle = true;

            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (toggle)
            {
                foreach (var item in enemies)
                {
                    item.GetComponent<Collider>().enabled = false;
                    item.GetComponent<MeshRenderer>().enabled = false;
                }
                toggle = false;
            }
            else
            {
                foreach (var item in enemies)
                {
                    item.GetComponent<Collider>().enabled = true;
                    item.GetComponent<MeshRenderer>().enabled = true;
                }
                toggle = true;

            }
        }
    }
}
