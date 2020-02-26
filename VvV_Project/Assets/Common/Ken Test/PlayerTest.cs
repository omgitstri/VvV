using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{

    #region - VARIABLES -

    Rigidbody rb;
    CapsuleCollider col;

    [SerializeField]private float walkSpd = 10f;

    #endregion


    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        col = this.GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
    }

    void Walk()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        Vector3 moveDir = Vector3.zero;


        moveDir = new Vector3(horizontal, 1f, vertical).normalized;
        transform.Translate(moveDir * walkSpd * Time.deltaTime);

        var pos = transform.position;
        pos.y = 1f;

        transform.position = pos;


    }
}
