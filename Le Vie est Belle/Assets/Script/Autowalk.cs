/*
	REFERENCE:
	Autowalk: https://youtu.be/JmgOeQ3Gric
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autowalk : MonoBehaviour {
	public float speed = 2.0f;
	public bool moveForward;
	private Transform centerCam;
	private Transform centerCon;
	private CharacterController controller;



	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();

		//centerCam = Camera.main.transform;
		centerCon = GameObject.FindWithTag("Right Hand").transform;
	}

	// Update is called once per frame
	void Update () {
		
		if (OVRInput.Get (OVRInput.Button.PrimaryIndexTrigger) || Input.GetButtonDown ("Fire1")) {

			moveForward = true;
		} else { moveForward = false;
		}

		if (moveForward){

			Vector3 forward = centerCon.TransformDirection (Vector3.forward);
			controller.SimpleMove (forward * speed);
		}
	}



}
