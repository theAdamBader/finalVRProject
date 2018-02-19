using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPoint : MonoBehaviour {

	public GameObject player;
	public Transform spawnPoints;

	// Use this for initialization
	void Start () {
		Instantiate (player, spawnPoints.position, spawnPoints.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
