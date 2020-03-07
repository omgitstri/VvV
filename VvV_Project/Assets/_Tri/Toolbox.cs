using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Toolbox : MonoBehaviour
{
    public delegate void GenericAction();

    public IEnumerator Timer(GenericAction _repeatAction, float _waitTime)
    {
        float elapsedTime = 0f;
        
        while (elapsedTime < _waitTime)
        {
            _repeatAction.Invoke();
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    public IEnumerator Timer(GenericAction _startAction, GenericAction _repeatAction, GenericAction _endAction, float _waitTime)
    {
        float elapsedTime = 0f;
        
        _startAction.Invoke();

        while (elapsedTime < _waitTime)
        {
            _repeatAction.Invoke();
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _endAction.Invoke();
    }

    public IEnumerator InterpolateValue(float _waitTime)
    {
        float elapsedTime = 0f;

        while (elapsedTime < _waitTime)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

}
