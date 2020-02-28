using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandController : MonoBehaviour
{
    [SerializeField]
    private PlayerHand currentHand = null;

    private bool isAttack = false;
    //private bool isSwing = false;

    private RaycastHit hitInfo = new RaycastHit();
    private Camera cam = null;

    private AudioSource audioSource = null;

    private void Start()
    {
        cam = FindObjectOfType<Camera>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        isAttack = false;
        //isSwing = false;
    }

    void Update()
    {
        TryAttack();
    }

    private void TryAttack()
    {
        if (Input.GetButton("Fire1"))
        {
            if (!isAttack)
            {
                StartCoroutine(AttackCoroutine());
            }
        }
    }

    IEnumerator AttackCoroutine()
    {
        isAttack = true;
        currentHand.anim.SetTrigger("Attack");
        //isSwing = true;

        StartCoroutine(HitCoroutine());

        PlaySE(currentHand.hand_Sound);
        yield return new WaitForSeconds(currentHand.attackDelay);

        //isSwing = false;
        isAttack = false;
    }

    IEnumerator HitCoroutine()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo, currentHand.range))
        {
            var individualCube = hitInfo.transform.GetComponent<IndividualCube>();
            var adjacencyGraph = hitInfo.transform.root.GetComponent<CreateAdjacencyGraph>();

            if (hitInfo.transform.tag == "WeakPoint")
            {
                individualCube.DestroyParent();
            }

            if (hitInfo.transform.tag == "Enemy")
            {
                //Have fun~ ( ￣ 3￣)y▂ξ

                IndividualCube weakPoint = null;
                weakPoint = adjacencyGraph.GetWeakPoint();

                hitInfo.transform.GetComponent<IndividualCube>().MarkAsHit(2);
                weakPoint.transform.root.GetComponent<CreateAdjacencyGraph>().DestroyHit();

                weakPoint.GetComponent<IndividualCube>().CheckDetached();
                weakPoint.transform.root.GetComponent<CreateAdjacencyGraph>().DestroyDetached();
            }
        }

        yield return null;
    }

    private void PlaySE(AudioClip _clip)
    {
        audioSource.clip = _clip;
        audioSource.Play();
    }
}
