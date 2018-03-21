using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeRespawn : MonoBehaviour {

	public GameObject enemy;
	public Transform[] spawnPoints;

	// Use this for initialization
	void Start () {
		int spawnPointArray = Random.Range (0, spawnPoints.Length);

		Instantiate (enemy, spawnPoints [spawnPointArray].position, spawnPoints [spawnPointArray].rotation);
	}
		

}
