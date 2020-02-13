using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    private static TargetManager _instance;
    public static TargetManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject(nameof(TargetManager)).AddComponent<TargetManager>();
            }
            return _instance;
        }
    }

    private List<Transform> targets = new List<Transform>();

    public Transform current;

    public void RegisterTarget(Transform _transform)
    {
        targets.Add(_transform);
        if (current == null)
        {
            current = targets[0];
        }
    }

    public Transform GetCurrentTarget()
    {
        return current;
    }

    [ContextMenu("next")]
    public Transform GetNextTarget(Transform _current)
    {
        Transform nextTarget;

        int index = targets.IndexOf(_current);
        if (index < targets.Count - 1)
        {
            index++;
            nextTarget = targets[index];
        }
        else
        {
            index = 0;
            nextTarget = targets[index];
        }
        return nextTarget;
    }

    [ContextMenu("previous")]
    public Transform GetPreviousTarget(Transform _current)
    {
        Transform previousTarget;

        int index = targets.IndexOf(_current);
        if (index > 0)
        {
            index -= 1;
            previousTarget = targets[index];
        }
        else
        {
            index = targets.Count - 1;
            previousTarget = targets[index];
        }
        return previousTarget;
    }
}
