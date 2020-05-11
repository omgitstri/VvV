using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomInputEvent : MonoBehaviour
{
    [System.Serializable]
    public class Rawr
    {
        [HideInInspector] public string name = null;
        public KeyCode keyCode = new KeyCode();
        public UnityEvent KeyInputDownEvent;
    }

    public List<Rawr> rawr;

    private void Update()
    {
        foreach (var item in rawr)
        {
            if (Input.GetKeyDown(item.keyCode))
            {
                item.KeyInputDownEvent.Invoke();
            }
        }
    }

    private void OnValidate()
    {
        foreach (var item in rawr)
        {   
            item.name = "Input Key: " + item.keyCode.ToString();
        }
    }
}
