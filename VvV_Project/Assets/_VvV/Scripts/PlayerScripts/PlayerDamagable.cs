using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamagable : Damagable
{

    [SerializeField] private int currentHitPoint = 5;
    [SerializeField] private int maxHitPoint = 5;

    [SerializeField] private float invulnerableDelay = 0;
    [SerializeField] private float invulnerableTime = 3;
    private SoundFX sfx;
    private AudioSource audioSource;
    [Space]
    [SerializeField]private CameraShake camShake;
    [SerializeField] private float shakeDuration;
    [SerializeField] private float shakeMagnitude;


    private void Start()
    {
        currentHitPoint = maxHitPoint;
        sfx = GetComponent<SoundFX>();
        audioSource = GetComponent<AudioSource>();
    }

    public float HealthPercentage()
    {
        return (float)currentHitPoint / (float)maxHitPoint;
    }

    public float GetInvulnerableDelay()
    {
        return invulnerableDelay;
    }

    public float GetInvulnerableTime()
    {
        return invulnerableTime;
    }

    public override void GetDamaged(int dmg)
    {

        Toolbox.GetInstance.GetUI().UpdatePlayerHP(currentHitPoint);
        if (currentHitPoint > 0 && invulnerableDelay <= 0)
        {
            currentHitPoint -= dmg;
            invulnerableDelay = invulnerableTime;
            StartCoroutine(camShake.Shake(shakeDuration, shakeMagnitude));

            if (audioSource != null) {
                sfx.PlaySound(audioSource, Toolbox.GetInstance.GetSound().hurt, true, 0.75f, 1f, 1f, 2f);
            }
        }
    }

    private void Update()
    {
        //triggered damage 
        if (invulnerableDelay > 0)
        {
            GetComponent<Renderer>().material.SetColor("_BaseColor", Color.red);
            GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }
        //reset vulnerability
        else if(invulnerableDelay < 0 && currentHitPoint > 0)
        {
            GetComponent<Renderer>().material.SetColor("_BaseColor", Color.gray);
            GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
        }
        //dead
        else
        { 
            GetComponent<Renderer>().material.SetColor("_BaseColor", Color.black);
            GetComponent<Renderer>().material.SetColor("_Color", Color.black);
        }

        invulnerableDelay -= Time.deltaTime;
        PlayerDeath();
    }

    private void PlayerDeath() {

        if (currentHitPoint <= 0) {
            

            if (audioSource.clip != Toolbox.GetInstance.GetSound().death) {
                sfx.PlaySound(audioSource, Toolbox.GetInstance.GetSound().death, false, 0.75f, 0.75f, 1f, 1f);
            }

            StartCoroutine(Death());
        }
    }

    public IEnumerator Death() {
        this.GetComponent<PlayerController>().canMove = false;     // ** - TEMPORARY JUST TO STOP THE MOVEMENT ON DEATH - ** // - KEN
        StartCoroutine(camShake.Shake(audioSource.clip.length, shakeMagnitude * 1.15f));
        Toolbox.GetInstance.GetFade().FadeOut();
        Toolbox.GetInstance.GetMusic().FadeOut(0f);
        yield return new WaitForSeconds(audioSource.clip.length);
        Toolbox.GetInstance.GetScene().ReloadScene();

    }

}
