using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator = null;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetFloat("RandAttack", Random.value);
            animator.SetTrigger("AnyAttack");
            //animator.SetTrigger("ComboAttack");
        }
    }

    public void EnableMove()
    {
        GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * 500);
    }

    public void DisableMove()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
