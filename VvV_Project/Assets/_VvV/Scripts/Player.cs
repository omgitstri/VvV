using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int health = 10;
    [SerializeField] private float speed = 5f;

    private void Awake()
    {
        EntityTracker.Instance.AddEntity(Entity.PlayerEntity, this.gameObject);
    }

    void Update()
    {
        DoMovement();
    }

    public void DoMovement()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        Vector3 moveDirection = Vector3.zero;
        

        moveDirection = new Vector3(horizontal, 0, vertical).normalized;
        transform.Translate(moveDirection * speed * Time.deltaTime, Camera.main.transform);

        var pos = transform.position;
        pos.y = 0;

        transform.position = pos;

    }

    private void OnDestroy()
    {
        EntityTracker.Instance.RemoveEntity(Entity.PlayerEntity);
    }
}
