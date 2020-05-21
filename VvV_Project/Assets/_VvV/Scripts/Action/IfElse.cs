using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class IfElse : MonoBehaviour
{
    private Text txt = null;
    [SerializeField] private string _if = null;
    [SerializeField] private string _else = null;
    public UnityEvent _partAcquired = null;

    private void Awake()
    {
        txt = GetComponent<Text>();
    }

    public void OnEnable()
    {

        if(!Entity_Tracker.Instance.collectedPart)
        {
            txt.text = _if;
        }
        else
        {
            txt.text = _else;
            _partAcquired.Invoke();
        }
    }
}
