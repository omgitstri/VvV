using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempEnemy : MonoBehaviour
{
    [SerializeField] private GameObject player = null;
    [SerializeField] private float speed = 3f;
    [SerializeField] private float ratio = 0f;

    void Start()
    {
        player = EntityTracker.Instance.FindEntity(Entity.PlayerEntity);
    }


    void Update()
    {
        ChasePlayer();
    }

    public void IsHit()
    {

    }

    private void ChasePlayer()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 0.5f)
        {

        }


        ratio = 1 - Mathf.Exp(-speed * Time.deltaTime);

        transform.position = Vector3.Lerp(transform.position, player.transform.position, ratio);
    }
}
