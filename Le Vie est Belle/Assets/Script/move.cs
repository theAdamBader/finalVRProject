using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {

	public camMove ctnv; // For accessing a variable from the cameratestnotvr script
	public float speed = 30.0f;   // The speed the player moves at

	void Start() {

	}

	void Update() {

		// This transform's y axis will rotate around the h variable in the cameratestnotvr script
		this.transform.Rotate(0, ctnv.h, 0);

		// The player will rotate with euler angles
		transform.eulerAngles = new Vector3(0, ctnv.h, 0);

		// WASD for movement
		if(Input.GetKey("w")) {
			this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
		}
		if(Input.GetKey("s")) {
			this.transform.Translate(Vector3.back * speed * Time.deltaTime);
		}
		if(Input.GetKey("a")) {
			this.transform.Translate(Vector3.left * speed * Time.deltaTime);
		}
		if(Input.GetKey("d")) {
			this.transform.Translate(Vector3.right * speed * Time.deltaTime);
		}
	}
}
