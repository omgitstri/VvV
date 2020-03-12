using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateTHis : MonoBehaviour
{

    public void InstantiateThis(Transform _transform)
    {
        var go = Instantiate<GameObject>(this.gameObject);
        if (_transform != null)
        {
            go.transform.position = _transform.position;
        }
        else
        {
            go.transform.position = Vector3.zero;
        }
    }
}
