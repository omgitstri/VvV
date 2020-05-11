using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomVisibleEvent : MonoBehaviour
{
    public UnityEvent onBecomeVisible;
    public UnityEvent onBecomeInvisible;

    private void OnBecameVisible()
    {
        onBecomeVisible.Invoke();
    }

    private void OnBecameInvisible()
    {
        onBecomeInvisible.Invoke();
    }
}
