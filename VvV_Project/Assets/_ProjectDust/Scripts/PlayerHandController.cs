using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandController : MonoBehaviour
{
    [SerializeField]
    private PlayerHand currentHand;

    private bool isAttack = false;
    private bool isSwing = false;

    private RaycastHit hitInfo;
    private Camera cam;

    private AudioSource audioSource;

    private void Start()
    {
        cam = FindObjectOfType<Camera>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        isAttack = false;
        isSwing = false;
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
        isSwing = true;

        StartCoroutine(HitCoroutine());

        PlaySE(currentHand.hand_Sound);
        yield return new WaitForSeconds(currentHand.attackDelay);

        isSwing = false;
        isAttack = false;
    }

    IEnumerator HitCoroutine()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo, currentHand.range))
        {
            if (hitInfo.transform.tag == "WeakPoint")
            {
                hitInfo.transform.GetComponent<IndividualCube>().DestroyParent();
            }

            if (hitInfo.transform.tag == "Enemy")
            {
                //Have fun~ ( ￣ 3￣)y▂ξ
                //hitInfo.transform.gameObject.GetComponent<IndividualCube>().AddRigidbodyToNeighbours();
                //print(hitInfo.transform.root.GetComponent<CreateAdjacencyGraph>().weekPoint.GetComponent<IndividualCube>().voxelPosition);

                GameObject weakPoint = null;
                weakPoint = hitInfo.transform.root.GetComponent<CreateAdjacencyGraph>().GetWeakPoint();

                hitInfo.transform.GetComponent<IndividualCube>().MarkAsHit(2);
                weakPoint.transform.root.GetComponent<CreateAdjacencyGraph>().DestroyHit();

                //hitInfo.transform.GetComponent<IndividualCube>().DestroyCube();
                //Destroy(hitInfo.transform.gameObject);

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
