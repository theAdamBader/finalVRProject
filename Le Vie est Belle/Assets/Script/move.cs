using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {
	
	public float speed = 3.0f;   // The speed the player moves at

	void Start() {

	}

	void Update() {


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
