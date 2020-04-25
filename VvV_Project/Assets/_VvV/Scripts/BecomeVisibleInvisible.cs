using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BecomeVisibleInvisible : MonoBehaviour
{
    Collider[] col = new Collider[] { };
    Camera cam = null;

    private void Start()
    {
        cam = Entity_Tracker.Instance.PlayerEntity.GetComponentInChildren<Camera>();

        var tempCol = new List<Collider>();
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).TryGetComponent(out EnemyDamagable enemyDamagable))
            {
                tempCol.Add(enemyDamagable.GetComponent<Collider>());
            }
        }

        col = tempCol.ToArray();
    }

    //private void Update()
    //{
    //    if (cam.WorldToViewportPoint(transform.position).x > 0.4
    //        && cam.WorldToViewportPoint(transform.position).x < 0.6
    //        && cam.WorldToViewportPoint(transform.position).y > 0.4
    //        && cam.WorldToViewportPoint(transform.position).y < 0.6)
    //    {
    //        foreach (var item in col)
    //        {
    //            if (item.enabled == false)
    //            {
    //                item.enabled = true;
    //            }
    //        }
    //    }
    //    else
    //    {
    //        foreach (var item in col)
    //        {
    //            if (item.enabled == true)
    //            {
    //                item.enabled = false;
    //            }
    //        }
    //    }
    //}

    private void OnBecameVisible()
    {
        //Debug.Log("visible");
        foreach (var item in col)
        {
            item.enabled = true;
        }
    }

    private void OnBecameInvisible()
    {
        foreach (var item in col)
        {
            item.enabled = false;
        }
    }
}
