using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class EnemyAttackCube_Intepolation : MonoBehaviour
{
    public Transform start, stop;
    public List<Transform> middle = new List<Transform>();
    public Vector3 lastPosition = Vector3.zero;
    public Vector3 radius = Vector3.zero;
    public Enemy_AttackManager root = null;

    public Vector3 startPos;

    public IndividualCube parent;

    public bool attack = false;
    public bool reverse = false;


    public int dmg = 1;

    private void Start()
    {
        radius = (Random.insideUnitSphere * 0.25f);
    }

    void Update()
    {
        if (attack)
        {
            Attack();
        }
        if (reverse)
        {
            Return();
        }
    }

    public void Attack()
    {
        if (middle.Count > 0 && start != null && stop != null && root != null)
        {
            transform.SetParent(null);
            //List<Vector3> lerps = new List<Vector3>();
            //for (int i = 0; i < middle.Count; i++)
            //{
            //    if (i == 0)
            //    {
            //        lerps.Clear();
            //        lerps.Add(Vector3.Slerp(startPos, middle[i].position + radius, root.a));
            //    }
            //    else
            //    {
            //        lerps.Add(Vector3.Slerp(lerps[i - 1], middle[i].position + radius, root.a));
            //    }
            //}

            //transform.position = Vector3.Slerp(lerps[lerps.Count - 1], stop.position + radius, root.a);
            var lerp = Vector3.Slerp(start.position, middle[Random.Range(0, middle.Count)].position + radius, root.a);
            transform.position = Vector3.Slerp(lerp, stop.position + radius, root.a);
        }
    }

    public void Return()
    {
        transform.position = Vector3.Slerp(lastPosition, parent.transform.position, root.a);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerDamagable>(out PlayerDamagable player))
        {
            player.GetDamaged(dmg);

        }

        if(other.TryGetComponent(out EMPDamagable emp))
        {
            emp.GetDamaged(dmg);
        }
    }
}