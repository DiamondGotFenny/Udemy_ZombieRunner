using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearArea02 : MonoBehaviour {

    private bool foundCA = false;
    // Use this for initialization
    void Start () {
        foundCA = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //this script is for the collider of selected locations for clear area;
    //not for the clear area dectection collider attached under player;
    private void OnTriggerEnter(Collider other)
    {
        GameObject player = GameObject.Find("Player");
        GameObject helicopter = GameObject.Find("Helicopter");
        Collider collider = player.GetComponent<Collider>();

        if (other == collider && Time.timeSinceLevelLoad > 10f && !foundCA)
        {
            player.BroadcastMessage("OnFindClearArea");
            helicopter.BroadcastMessage("GetTargetPosistion", transform.position);
            foundCA = true;
        }
    }
}
