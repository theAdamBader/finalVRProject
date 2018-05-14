using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyPortal : MonoBehaviour {

	// This script destroys the portal when the player enters the second puzzle
	public GameObject portalCollider;
	public GameObject portal;

	void OnTriggerEnter (Collider destroyPortal)
	{
		if (destroyPortal.tag == "Player")
		{
			Destroy (portalCollider);
			Destroy (portal);
		}
	}
}
