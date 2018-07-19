using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Helicopter : MonoBehaviour {

    public float speed = 50f;
    //public float landingSpeed = 5f;
    public float upSpeed = 30f;

    bool isCalled = false;
    bool win = false;
    bool lost = false;

    public GameObject gameManager;

    //Rigidbody myRigidBody;
    Vector3 targetPos;

    // Use this for initialization
    void Start () {
        //myRigidBody = GetComponent<Rigidbody>();
	}

    private void FixedUpdate()
    {
        if (isCalled)
        {
            float step = speed * Time.deltaTime;
            Vector3 targetPostition = new Vector3(targetPos.x,
                                         this.transform.position.y,
                                         targetPos.z);
            this.transform.LookAt(targetPostition);
            transform.position = Vector3.MoveTowards(transform.position, targetPos, step);            
        }

        if (win)
        {
            isCalled = false;
            Debug.Log("Heli move up");
            transform.position += Vector3.up * upSpeed * Time.deltaTime;
            gameManager.SendMessage("OnWin");
        }
    }

    public  void OnDispatchHeli()
    {
            //myRigidBody.velocity = new Vector3(0, 0, 50f);
            isCalled = true;
            Debug.Log("Helicopter called");  
    }

    Vector3 GetTargetPosistion(Vector3 pos)
    {
        float posX = pos.x;
        float posY = pos.y -1f;
        float posZ = pos.z;
        return targetPos = new Vector3(posX,posY,posZ);
    }

    private void OnTriggerEnter(Collider other)
    {
        //create victory method;
        if (other.tag=="Player")
        {
            Debug.Log("we win");
            win = true;
        }
        else if (other.tag=="Enemy")
        {
            Debug.Log("we Lost");
            GameObject.Find("GameManager").SendMessage("OnLost");
        }

    }
}
