using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpUI : MonoBehaviour
{
    [SerializeField] private RawImage img = null;
    public bool placedPickup { get; set; } = false;

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
            }
        }
        else
        {
            img.color = new Color(0.4f, 0f, 1f);
        }
    }
}
