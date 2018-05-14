/*
	REFERENCE:
	Autowalk: https://youtu.be/JmgOeQ3Gric
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script handles movement with the Samsung gear VR controller
public class Autowalk : MonoBehaviour {

	public float speed = 2.0f;
	public bool moveForward;
	private Transform centreCon;
	private CharacterController controller;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();

		// Finds the game object called "Right Hand"
		centreCon = GameObject.FindWithTag("Right Hand").transform;
	}

	// Update is called once per frame
	void Update () {

		// If you push the trigger button then the player would move forward
		// If the trigger is released then the player would stop moving
		if (OVRInput.Get (OVRInput.Button.PrimaryIndexTrigger)) {

			moveForward = true;
		} 
		else { 
			moveForward = false;
		}

		// If the controller is centered some where then it calls the simple and gives a new point to move forward
		if (moveForward){
			Vector3 forward = centreCon.TransformDirection (Vector3.forward);
			controller.SimpleMove (forward * speed);
		}
	}
}