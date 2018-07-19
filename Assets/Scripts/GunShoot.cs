using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunShoot : MonoBehaviour {

    public int damagePerShot = 10;
    public float timeBetwenShots = 0.15f;
    public float ShotRange = 100f;
    public int bulletVolume = 100;
    public Text bulletDisplay;

    PlayerHealth playerHealth;
    float timer;
    Ray shootRay;
    RaycastHit shootHit;
    ParticleSystem gunParticle;
    AudioSource gunSound;
    LineRenderer gunLine;
    Light gunLight;
    float ExDisplayTime = 0.2f;
    Animator anitor;

	// Use this for initialization
	void Start () {
        playerHealth = GetComponentInParent<PlayerHealth>();
        gunParticle = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        gunLight = GetComponent<Light>();
        gunSound = GetComponent<AudioSource>();
        anitor = GetComponentInParent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (Input.GetButton("Fire1") && timer >= timeBetwenShots && bulletVolume > 0&&playerHealth.CurrentHealth>0)
        {
            Shoot();
        }
        else if (timer>=timeBetwenShots*ExDisplayTime)
        {
            DisableEffect();
        }
     
        bulletDisplay.text = bulletVolume.ToString();
	}

    public void DisableEffect()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
        anitor.SetBool("Fire", false);
    }

    void Shoot()
    {
        timer = 0;
        gunSound.Play();
        gunParticle.Stop();
        gunParticle.Play();
        gunLine.enabled = true;
        gunLight.enabled = true;
        anitor.SetBool("Fire",true);
        bulletVolume--;
        gunLine.SetPosition(0, transform.position);
        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;
        if (Physics.Raycast(shootRay, out shootHit, ShotRange))
        {
            EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damagePerShot, shootHit);
            }
            gunLine.SetPosition(1, shootHit.point);
        }
        else
        {
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * ShotRange);
        }
    }

    //a function to recharge bulletVolum;
    public void rechargeAmmo(int ammo)
    {
        bulletVolume += ammo;
        Debug.Log("add ammo");
    }
}
