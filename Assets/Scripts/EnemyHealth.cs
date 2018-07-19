using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {
    public int StartingHealth = 100;
    public int currentHealth;
    public int scoreValue;
     AudioSource enemyaudio;
    public AudioClip deathClip;
    public AudioClip hurtClip;
    //NavMeshAgent nav;

    Animator animt;
    ParticleSystem hitParticle;

   public bool isDead=false;
  public  bool isDamage=false;

    void Awake()
    {
        
    }



    private void Start()
    {
        animt = GetComponent<Animator>();

        hitParticle = GetComponentInChildren<ParticleSystem>();
        enemyaudio = GetComponent<AudioSource>();
       // nav = GetComponent<NavMeshAgent>();
    }

    void Update()
    {

    }
    public void TakeDamage(int amount,RaycastHit hit)
    {
        if (isDead)
            {
                return;
            }
            isDamage = true;
           //nav.enabled=false;
        enemyaudio.clip = hurtClip;
        enemyaudio.Play();
        currentHealth -= amount;
        hitParticle.transform.position = hit.point;
        hitParticle.Play();
            if (currentHealth > 0)
            {
                animt.SetBool("IsDamage", true);            
            }
            if (currentHealth <= 0)
            {
                Dead();
                GameObject.Destroy(this.gameObject, 4f);
        }
    }

    public void Dead()
    {
        isDead = true;
        animt.SetBool("IsAttack", false);
        animt.SetBool("IsDamage", false);
        animt.SetTrigger("IsDead");
        GetComponent<NavMeshAgent>().enabled = false;
        if (GetComponent<SphereCollider>() !=null)
        {
            GetComponent<SphereCollider>().enabled = false;
        }    
        GetComponent<CapsuleCollider>().enabled = false;
        enemyaudio.clip = deathClip;
        enemyaudio.Play();
    }
}
