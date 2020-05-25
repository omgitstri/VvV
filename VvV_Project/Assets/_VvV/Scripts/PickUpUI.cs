using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PickUpUI : MonoBehaviour
{
    [SerializeField] private RawImage img = null;
    public bool placedPickup { get; set; } = false;
    public UnityEvent PickedUpEvent = null;

    void Update()
    {
        if (!placedPickup)
        {
            if (Entity_Tracker.Instance.enemyPart != null && !Entity_Tracker.Instance.collectedPart)
            {
                img.color = Color.red;
            }
            else if (Entity_Tracker.Instance.enemyPart != null && Entity_Tracker.Instance.collectedPart)
            {
                img.color = Color.green;
                PickedUpEvent.Invoke();
            }
        }
        else
        {
            img.color = new Color(0.4f, 0f, 1f);
        }
    }
}
