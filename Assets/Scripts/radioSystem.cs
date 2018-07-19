using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class radioSystem : MonoBehaviour {

    public AudioClip initialHeliCall;
    public AudioClip initialCallReply;
    public AudioClip airPlane;
    public AudioClip askAmmo;
    public AudioClip copyThat;

    public float ammoRechargeTime = 60f;
    public GameObject AmmoPrefab;
    public Text Countdown;

    bool ableToAmmo = false;
    float timer;
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}

    private void Update()
    {
        Countdown.text = ammoRechargeTime.ToString();

        if (ableToAmmo)
        {
            ammoRechargeTime -= Time.deltaTime;
            if (ammoRechargeTime<=0)
            {
                ammoRechargeTime = 0;
            }

            Countdown.color = Color.blue;
        }
        else
        {
            Countdown.color = Color.gray;
        }
    }

    void OnMakeInitialHeliCall()
    {
        print(name + " OnMakeInitialHeliCall");
        audioSource.clip = initialHeliCall;
        audioSource.Play();
        Invoke("InitialReply", initialHeliCall.length + 1f);
    }

    void InitialReply()
    {
        audioSource.clip = initialCallReply;
        audioSource.Play();
        BroadcastMessage("OnDispatchHeli");
        ableToAmmo = true;
    }

    void OnReplyAmmo()
    {
        Debug.Log("receive ammo request");
        audioSource.clip = askAmmo;
        audioSource.Play();
        Invoke("AnswerForAmmoRequest", askAmmo.length+2f);
    }

    void InstantiateAmmo()
    {
        GameObject player = GameObject.Find("Player");
        float xPos = player.transform.position.x;
        float yPos = player.transform.position.y + 8f;
        float zPos = player.transform.position.z + 4f;
        Vector3 ammoPos = new Vector3(xPos, yPos, zPos);
        Instantiate(AmmoPrefab, ammoPos, Quaternion.identity);
    }

    void AnswerForAmmoRequest()
    {
        if (ableToAmmo && ammoRechargeTime <= 0)
        {
            Debug.Log("able to deliver");
            audioSource.clip = copyThat;
            audioSource.Play();
            audioSource.clip = airPlane;
            audioSource.Play();
            Invoke("InstantiateAmmo", airPlane.length);
            //airfreighter sound before instantiate;
            //text color change before able to call supply;
            ammoRechargeTime = 60f;
        }
    }
}
