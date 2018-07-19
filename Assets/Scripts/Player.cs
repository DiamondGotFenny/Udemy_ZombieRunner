using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public Transform PlayerSpawnManager;
    public Helicopter helicopter;
    public GameObject Flare;

    private Transform[] playerSpawnPoint;
    private bool respawn = false;
    private bool lastRespawnToggle = false;
    private AudioSource[] audiosources;

    Rigidbody myrigidbody;

    // Use this for initialization
    void Start () {
        playerSpawnPoint = PlayerSpawnManager.GetComponentsInChildren<Transform>();

        myrigidbody = GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void Update () {
        if (respawn !=lastRespawnToggle)
        {
            respawnPlayer();
            respawn = false;
        }
        else
        {
           lastRespawnToggle=respawn;
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            SendMessageUpwards("OnReplyAmmo");
        }


    }

    void respawnPlayer()
    {
        int i = Random.Range(1, playerSpawnPoint.Length);
        transform.position = playerSpawnPoint[i].transform.position;
    }

    void OnFindClearArea()
    {
        Invoke("DropFlare", 1f);
    }

    void DropFlare()
    {
        //drop flare
        Instantiate(Flare, transform.position, transform.rotation);
        GameObject.Find("GameManager").SendMessage("FlareLaid");
    }

    public void OnRespawn()
    {
        respawn = true;
    }
    

}
