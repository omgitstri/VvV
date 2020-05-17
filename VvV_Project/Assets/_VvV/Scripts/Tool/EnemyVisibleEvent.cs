using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyVisibleEvent : MonoBehaviour
{
    [SerializeField] LayerMask layerMask = ~0;
    public UnityEvent onBecomeVisible;
    public UnityEvent onBecomeInvisible;

    private void OnBecameVisible()
    {
        Ray ray = new Ray(transform.position, Entity_Tracker.Instance.PlayerEntity.transform.position - transform.position);
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit)
            && layerMask == (layerMask | 1 << hit.transform.gameObject.layer))
        {
            onBecomeVisible.Invoke();
        }
    }

    private void OnBecameInvisible()
    {
        onBecomeInvisible.Invoke();
    }
}
