using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    [SerializeField]
    GameObject ZombiePrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnStart()
    {
        Debug.Log("EnemySpawn see flare");
        InvokeRepeating("SpawnEnemy", 0.1f, 20f);
    }

    void SpawnEnemy()
    {
       GameObject zombieClone= Instantiate(ZombiePrefab, transform.position, Quaternion.identity) as GameObject;
    }
}
