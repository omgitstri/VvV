using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class FunctionDelay : MonoBehaviour
{
    [SerializeField] private UnityEvent callBack = new UnityEvent();
    float delayTime = 0;

    public void UseDelay(float _delay)
    {
        StopAllCoroutines();
        delayTime = _delay;
        StartCoroutine(nameof(DelayInvoke));
    }

    public IEnumerator DelayInvoke()
    {
        while (delayTime >= 0)
        {
            delayTime -= Time.deltaTime;
            yield return null;
        }
        callBack.Invoke();
    }
}
