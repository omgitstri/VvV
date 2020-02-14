using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField] private string messageContent = null;
    [SerializeField] private List<EventManagerVariable> events = null;

    private void OnValidate()
    {
        for (int i = 0; i < events.Count; i++)
        {
            events[i].elementName = "Event Set: " + (i + 1);
        }
    }

    public IEnumerator StartEvent()
    {
        for (int i = 0; i < events.Count; i++)
        {
            yield return new WaitForSeconds(events[i].delaySeconds);

            for (int j = 0; j < events[i].triggeredObjects.Length; j++)
            {
                if (events[i].triggeredObjects[j] != null)
                {
                    events[i].triggeredObjects[j].SendMessage(messageContent, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }

    private void Start()
    {
        //StartCoroutine(StartEvent());
    }


}

[System.Serializable]
public class EventManagerVariable
{
    [Header("Element Name"),HideInInspector]
    public string elementName;
    [Header("Delays before trigger")]
    public float delaySeconds;
    [Header("List of Triggered Objects")]
    public Transform[] triggeredObjects;
}
