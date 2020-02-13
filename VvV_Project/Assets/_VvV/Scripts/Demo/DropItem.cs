using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public Looot loot;

    private void OnDestroy()
    {
        loot.dropKey -= 1;
    }
}
