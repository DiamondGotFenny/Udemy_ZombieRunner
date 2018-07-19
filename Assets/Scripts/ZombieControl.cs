using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieControl : MonoBehaviour {

    GameObject player;
    Transform PlayerTran;
    Animator animt;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    bool attacking = false;
    bool isFlare = false;
    NavMeshAgent nav;
    float timer;
   public float followRang =10f; //change into private after done;
    

    AudioSource enemyaudio;
    public AudioClip attackClip;

    public int damage=50;
    public float wanderRadius=20f;
    public float wanderTimer = 10f;
    //public Animation anmtn;

    private void OnEnable()
    {
        timer = wanderTimer;
    }


    // Use this for initialization
    void Start () {
        enemyaudio = GetComponent<AudioSource>();
        player = GameObject.Find("Player");
        PlayerTran = player.GetComponent<Transform>();
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        animt = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        float targetDist = Vector3.Distance(transform.position, PlayerTran.position);
        if (targetDist<followRang||isFlare||player)
        {
             nav.SetDestination(PlayerTran.position);  //if nav.enabled needed to be false in future, add coroutine to call it later in else condition;        
        }
        else
        {
            if (timer > wanderTimer)
            {
                Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
                nav.SetDestination(newPos);  //if nav.enabled needed to be false in future, add coroutine to call it later in else condition;            
                timer = 0;
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            if (playerHealth != null)
            {
                nav.enabled = false;
                enemyaudio.clip = attackClip;
                enemyaudio.Play();
                animt.SetBool("IsAttack", true);
                attacking = true;
            }
            if (playerHealth == null)
            {
                return;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            nav.enabled = true;
            animt.SetBool("IsAttack", false);
            attacking = false;
        }
    }

    void Attack()
    {
        if (PlayerTran != null)
        {
            playerHealth.HealthChange(-damage);
        }
        else
        {
            return;
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);
        return navHit.position;
    }

    void SeeFlare()
    {
        animt.speed = 2f;  //change the animation speed after flare
        nav.speed = 3f;
         isFlare = true;
    }
}
