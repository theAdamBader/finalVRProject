using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyPortal : MonoBehaviour {

	public GameObject portalCollider;
	public GameObject portal;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider destroyPortal)
	{
		if (destroyPortal.tag == "Player")
		{
			Destroy (portalCollider);
			Destroy (portal);
		}
	}
}
