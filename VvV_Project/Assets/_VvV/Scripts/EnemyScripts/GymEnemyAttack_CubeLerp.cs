using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class GymEnemyAttack_CubeLerp : MonoBehaviour
{

    public Transform start, stop;
    public List<Transform> middle = new List<Transform>();
    public Vector3 radius = Vector3.zero;
    public Enemy_AttackManager root = null;

    public Vector3 startPos;

    public Transform parent;

    public bool attack = false;
    public bool reverse = false;
    //public BoxCollider box = null;


    public int dmg = 1;

    private void Start()
    {
        //box = this.GetComponent<BoxCollider>();
        //DeactivateHitbox();
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

            //if (attack)
            //{
            //    ActivateHitbox();
            //}

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
       // DeactivateHitbox();
        transform.localPosition = Vector3.Slerp(transform.localPosition, Vector3.zero, root.a);
    }

    //public IEnumerator ReactivateHitbox()
    //{
    //    yield return new WaitForSeconds(2f);
    //    ActivateHitbox();
    //}

    //public void ActivateHitbox()
    //{

    //    box.enabled = true;
    //}

    //public void DeactivateHitbox()
    //{
    //    box.enabled = false;
    //}

    private void OnTriggerEnter(Collider other)
    {
        ////Only damage the player if the cubes are in attack mode, this prevents the player from walking into the enemy & losing health
        //if (gameObject.layer == 29)
        //{
        if (other.TryGetComponent<PlayerDamagable>(out PlayerDamagable player))
        {
            //DeactivateHitbox();
            player.GetDamaged(dmg);

        }
        //}

        //else
        //{
        //    return;
        //}
    }
}