using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCrawl : MonoBehaviour
{
    ///  Handers
    private EnemyStats eStats;
    private EnemyMovementState enemyMovement = null;
    [SerializeField] private bool crawlTrigger = false;

    private void Start()
    {
        enemyMovement = transform.root.GetComponent<EnemyMovementState>();
        eStats = transform.root.GetComponent<EnemyStatsContainer>().eStats;

    }

    public void Crawl()
    {
        if (crawlTrigger)
        {
            enemyMovement.ActivateCrawl();
        }
    }
}
