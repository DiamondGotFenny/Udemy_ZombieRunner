using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddAmmo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        GameObject player = GameObject.FindObjectOfType<PlayerHealth>().gameObject;
        GunShoot muzzle = GameObject.FindObjectOfType<GunShoot>();
        if (collision.gameObject == player)
        {
            muzzle.rechargeAmmo(100);
            Destroy(gameObject, 1f);
        }
    }
}
