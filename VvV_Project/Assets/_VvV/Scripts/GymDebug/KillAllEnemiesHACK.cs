using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAllEnemiesHACK : MonoBehaviour
{
    public int triggerActive = 0;
    public List<CreateAdjacencyGraph> enemies = new List<CreateAdjacencyGraph>();

    public void TriggerActivated()
    {
        triggerActive += 1;
    }

    private void Update()
    {
        if(triggerActive >= 3)
        {
            foreach (var item in enemies)
            {
                item.DestroyAll();
            }
            triggerActive = 0;
        }
    }
}
