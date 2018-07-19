using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class ClearArea : MonoBehaviour {

//    public float TimeSinceLastTrigger = 0f;  //make it priavte when everything done;

//    private bool foundCA = false;

//	// Use this for initialization
//	void Start () {
//        foundCA = false;

//    }
	
//	// Update is called once per frame
//	void Update () {
//        TimeSinceLastTrigger += Time.deltaTime;
//        if (TimeSinceLastTrigger>1f&&Time.timeSinceLevelLoad>10f&& !foundCA)
//        {
//            SendMessageUpwards("OnFindClearArea");  //send message to its parent object's script-"Player", and call that methord;
//            foundCA = true;
//        }
//	}

//    private void OnTriggerStay(Collider other)
//    {
//        if (other.name!="Player")
//        {
//            TimeSinceLastTrigger = 0f;
//            Debug.Log(other.name);
//        }

//    }
    
//}
