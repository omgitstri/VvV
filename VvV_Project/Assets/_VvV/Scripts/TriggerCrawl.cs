using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCrawl : MonoBehaviour
{
    private Animator animator = null;
    [SerializeField] private bool crawlTrigger = false;

    private void Start()
    {
        animator = transform.root.GetComponent<Animator>();
    }

    public void Crawl()
    {
        if (crawlTrigger)
        {
            animator.SetBool("isCrawling", true);
        }
    }
}
