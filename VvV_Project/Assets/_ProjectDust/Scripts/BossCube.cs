using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCube : MonoBehaviour
{
    private Vector3 initPosition = Vector3.zero;
    private bool rawr = false;


    private void Awake()
    {
        initPosition = transform.position;
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(Random.Range(1f, 5f));
        print("test");
        Destroy(transform.GetComponent<Rigidbody>());
        rawr = true;
    }



    // Update is called once per frame
    void Update()
    {
        if (rawr)
        {
            ReturnPosition();
        }
    }

    void ReturnPosition()
    {
        transform.position = Vector3.Slerp(transform.position, initPosition, 5f * Time.deltaTime);
    }
}
