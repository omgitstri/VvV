using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class FunctionDelay : MonoBehaviour
{
    [SerializeField] private UnityEvent callBack = new UnityEvent();
    float delayTime = 0;
    bool startTimer = false;

    private void Update()
    {
        if (delayTime > 0 && startTimer == true)
        {
            delayTime -= Time.deltaTime;
        }
        else if (delayTime <= 0 && startTimer == true)
        {
            callBack.Invoke();
            startTimer = false;
        }
    }

    public void UseDelay(float _delay)
    {
        //StopAllCoroutines();
        delayTime = _delay;
        startTimer = true;
    }

    //public IEnumerator DelayInvoke()
    //{
    //    while (delayTime >= 0)
    //    {
    //        delayTime -= Time.deltaTime;
    //        yield return null;
    //    }
    //    callBack.Invoke();
    //}
}
