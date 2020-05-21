using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResupplyAmmo : MonoBehaviour
{
    public void Resupply()
    {
        Entity_Tracker.Instance.playerGun.carryBulletCount = Entity_Tracker.Instance.playerGun.maxBulletCount;
        Entity_Tracker.Instance.playerGun.currentBulletCount = Entity_Tracker.Instance.playerGun.reloadBulletCount;
    }
}
