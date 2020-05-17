using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField]
    private Gun currentGun = null;

    [SerializeField]
    private PlayerController player = null;

    private float currentFireRate = 1;
    private bool isReload = false;

    [HideInInspector]
    public bool isFineSightMode = false;

    private Vector3 originPos = Vector3.zero;
    private RaycastHit hitInfo = new RaycastHit();
    private Camera cam = null;

    private AudioSource audioSource = null;

    [SerializeField]
    private GameObject hitEffectPrefab = null;
    private SoundFX sfx = null;

    void Start()
    {
        originPos = Vector3.zero;
        cam = FindObjectOfType<Camera>();
        audioSource = GetComponent<AudioSource>();
        sfx = player.gameObject.GetComponent<SoundFX>();
    }


    private void OnEnable()
    {
        isReload = false;
        isFineSightMode = false;
        currentGun.transform.localPosition = Vector3.zero;
    }

    void Update()
    {
        GunFireRateCalc();
        TryFire();
        TryReload();
        TryFineSight();
    }

    private void GunFireRateCalc()
    {
        if (currentFireRate > 0)
            currentFireRate -= Time.deltaTime;
    }

    private void TryFire()
    {
        Toolbox.GetInstance.GetUI().UpdateAmmo(currentGun.currentBulletCount);
        if (Input.GetButton("Fire1") && currentFireRate <= 0 && !isReload)
        {
            Fire();
        }
    }

    private void Fire()
    {
        if (!isReload)
        {
            if (currentGun.currentBulletCount > 0)
                Shoot();
            else
            {
                CancelFineSight();
                StartCoroutine(ReloadCoroutine());
            }
        }
    }

    private void Shoot()
    {
        currentGun.currentBulletCount--;
        currentFireRate = currentGun.fireRate;
        //PlaySE(currentGun.fire_Sound);
        sfx.PlaySound(audioSource, Toolbox.GetInstance.GetSound().shoot, true, 0.20f, 0.30f, 0.85f, 1.25f);
        currentGun.muzzleFlash.Play();
        Hit();
        StopAllCoroutines();
        StartCoroutine(RetroActionCoroutine());
    }

    private void Hit()
    {
        if (Physics.Raycast(cam.transform.position + cam.transform.forward * 0.1f, cam.transform.forward, out hitInfo, currentGun.range))
        {
            GameObject hitEffect = Instantiate(hitEffectPrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            Destroy(hitEffect, 2f);

            var hit = hitInfo.transform.GetComponent<Damagable>();

            if(hit != null)
            {
                hit.GetDamaged(0);
            }

            //if (hitInfo.transform.CompareTag("WeakPoint"))
            //{
            //    hitInfo.transform.GetComponent<IndividualCube>().DestroyParent();
            //}

            //if (hitInfo.transform.CompareTag("Enemy"))
            //{
            //    //Have fun~ ( ￣ 3￣)y▂ξ
            //    IndividualCube weakPoint = null;
            //    weakPoint = hitInfo.transform.root.GetComponent<CreateAdjacencyGraph>().GetWeakPoint();

            //    hitInfo.transform.GetComponent<IndividualCube>().MarkAsHit(2);
            //    weakPoint.transform.root.GetComponent<CreateAdjacencyGraph>().DestroyHit();

            //    weakPoint.GetComponent<IndividualCube>().CheckDetached();
            //    weakPoint.transform.root.GetComponent<CreateAdjacencyGraph>().DestroyDetached();
            //}
        }
    }

    private void TryReload()
    {
        if (Input.GetKeyDown(KeyCode.R) && !isReload && currentGun.currentBulletCount < currentGun.reloadBulletCount)
        {
            CancelFineSight();
            StartCoroutine(ReloadCoroutine());
        }
    }

    IEnumerator ReloadCoroutine()
    {
        if (true)
        {
            isReload = true;

            //PlaySE(currentGun.reload_Sound);
            sfx.PlaySound(audioSource, Toolbox.GetInstance.GetSound().reload, true, 0.25f, 0.3f, 0.9f, 1f);
            currentGun.anim.SetTrigger("Reload");

            currentGun.carryBulletCount += currentGun.currentBulletCount;
            currentGun.currentBulletCount = 0;

            yield return new WaitForSeconds(currentGun.reloadTime);

            if (true)
            {
                currentGun.currentBulletCount = currentGun.reloadBulletCount;
                currentGun.carryBulletCount -= currentGun.reloadBulletCount;
            }

            //if (currentGun.carryBulletCount >= currentGun.reloadBulletCount)
            //{
            //    currentGun.currentBulletCount = currentGun.reloadBulletCount;
            //    currentGun.carryBulletCount -= currentGun.reloadBulletCount;
            //}
            //else
            //{
            //    currentGun.currentBulletCount = currentGun.carryBulletCount;
            //    currentGun.carryBulletCount = 0;
            //}
            isReload = false;
        }
        //else
        //{
        //    print("No Bullet");
        //}
    }

    private void TryFineSight()
    {
        if (Input.GetButtonDown("Fire2") && !isReload)
        {
            FineSight();
        }
    }

    public void CancelFineSight()
    {
        if (isFineSightMode)
            FineSight();
    }

    private void FineSight()
    {
        isFineSightMode = !isFineSightMode;
        currentGun.anim.SetBool("FineSightMode", isFineSightMode);

        if (isFineSightMode)
        {
            player.RunningCancel();
            StopAllCoroutines();
            StartCoroutine(FineSightActivateCoroutine());
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(FineSightDeactivateCoroutine());
        }
    }

    IEnumerator FineSightActivateCoroutine()
    {
        while (currentGun.transform.localPosition != currentGun.fineSightOriginPos)
        {
            if (cam.fieldOfView > 30)
            {
                cam.fieldOfView -= 1f;
            }
            currentGun.transform.localPosition = Vector3.Lerp(currentGun.transform.localPosition, currentGun.fineSightOriginPos, 0.2f);
            yield return null;
        }
    }

    IEnumerator FineSightDeactivateCoroutine()
    {
        while (currentGun.transform.localPosition != originPos)
        {
            if (cam.fieldOfView < 60)
            {
                cam.fieldOfView += 1f;
            }
            currentGun.transform.localPosition = Vector3.Lerp(currentGun.transform.localPosition, originPos, 0.2f);
            yield return null;
        }
    }

    IEnumerator RetroActionCoroutine()
    {
        Vector3 recoilBack = new Vector3(currentGun.retroActionForce, originPos.y, originPos.z);
        Vector3 retroActionRecoilBack = new Vector3(currentGun.retroActionFineSightForce, currentGun.fineSightOriginPos.y, currentGun.fineSightOriginPos.z);

        if (!isFineSightMode)
        {
            currentGun.transform.localPosition = originPos;

            while (currentGun.transform.localPosition.x <= currentGun.retroActionForce - 0.02f)
            {
                currentGun.transform.localPosition = Vector3.Lerp(currentGun.transform.localPosition, recoilBack, 0.4f);
                yield return null;
            }

            while (currentGun.transform.localPosition != originPos)
            {
                currentGun.transform.localPosition = Vector3.Lerp(currentGun.transform.localPosition, originPos, 0.1f);
                yield return null;
            }
        }
        else
        {
            currentGun.transform.localPosition = currentGun.fineSightOriginPos;

            while (currentGun.transform.localPosition.x <= currentGun.retroActionFineSightForce - 0.02f)
            {
                currentGun.transform.localPosition = Vector3.Lerp(currentGun.transform.localPosition, retroActionRecoilBack, 0.4f);
                yield return null;
            }

            while (currentGun.transform.localPosition != currentGun.fineSightOriginPos)
            {
                currentGun.transform.localPosition = Vector3.Lerp(currentGun.transform.localPosition, currentGun.fineSightOriginPos, 0.1f);
                yield return null;
            }
        }
    }


}
