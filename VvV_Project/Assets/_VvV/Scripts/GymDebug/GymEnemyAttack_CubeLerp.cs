using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class GymEnemyAttack_CubeLerp : MonoBehaviour
{

    public Transform start, stop;
    public List<Transform> middle = new List<Transform>();
    public Vector3 radius = Vector3.zero;
    public GymEnemy_AttackLerp root = null;

    public Vector3 startPos;

    public Transform parent;

    public bool attack = false;
    public bool reverse = false;

    [ContextMenu(nameof(Start))]
    private void Start()
    {
        radius = (Random.insideUnitSphere * 0.25f);
    }

    //private void OnEnable()
    //{
    //    parent = transform.parent;
    //    transform.SetParent(null);
    //}



    void Update()
    {
        if (attack)
            Attack();
        if (reverse)
            Return();
    }

    public void Attack()
    {
        if (middle.Count > 0 && start != null && stop != null && root != null)
        {

            List<Vector3> lerps = new List<Vector3>();
            for (int i = 0; i < middle.Count; i++)
            {
                if (i == 0)
                {
                    lerps.Clear();
                    lerps.Add(Vector3.Slerp(startPos, middle[i].position + radius, root.a));
                }
                else
                {
                    lerps.Add(Vector3.Slerp(lerps[i - 1], middle[i].position + radius, root.a));
                }
            }

            transform.position = Vector3.Slerp(lerps[lerps.Count - 1], stop.position + radius, root.a);
        }
    }

    public void Return()
    {
        transform.localPosition = Vector3.Slerp(transform.localPosition, Vector3.zero, root.a);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Damagable>(out Damagable player))
        {
            Debug.Log("damaged");
            player.GetDamaged();
        }

    }


}