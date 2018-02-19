using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camMove : MonoBehaviour {
	public float cspeed = 10.0f;   // The speed the camera moves at
	public float h = 0.0f;         // The horizontal position of the camera
	public float v = 0.0f;         // The vertical position of the camera
	public bool holding = false;   // Checks if holding something
	public bool havekey = false;   // Checks if got the key
	public GameObject floor;       // The floor game object, edit in the Inspector

	void Update() {

		this.transform.Rotate(v, h, 0);

		// The camera's X and Y axis is set to the mouse's X and Y position
		h += Input.GetAxis("Mouse X") * cspeed;
		v -= Input.GetAxis("Mouse Y") * cspeed;

		// The player will rotate with euler angles
		transform.eulerAngles = new Vector3(v, h, 0);

		// Reset the camera
		if(Input.GetKey("f")) {
			h = 0.0f;
			v = 0.0f;
		}
	}

	// If the player has the key, a message will show on the bottom-left saying "Got Key!"
	void OnGUI() {
		if(havekey == true) {
			GUI.Button(new Rect(Screen.width/20f, Screen.height/1.1f, 100, 20), new GUIContent("Got Key!"));
		}
	}

	void OnTriggerEnter(Collider coll) {
		// If an interactable, key or false key is within the player's range; it will light up
		if(coll.gameObject.tag == "Interactable" || coll.gameObject.tag == "Key" || coll.gameObject.tag == "FalseKey") {
			coll.gameObject.GetComponent<Light>().enabled = true;
		}

		// If a door is within the player's range and you have the key for it; it will light up
		if(coll.gameObject.tag == "Door" && havekey == true) {
			coll.gameObject.GetComponent<Light>().enabled = true;
		}
	}

	void OnTriggerStay(Collider coll){
		if(coll.gameObject.tag == "Interactable") {
			coll.gameObject.GetComponent<Light>().enabled = true;

			// If you hold left click on an interactable, you can pick it up; when you let go of left click, you will stop holding the interactable
			if(Input.GetMouseButton(0)){
				holding = true;
			} else {
				holding = false;
			}

			// When holding an interactable, it will not use gravity and will be a child of the player, this is so the interactable stays in a position relative to the player
			if(holding == true){
				coll.gameObject.GetComponent<Rigidbody>().useGravity = false;
				coll.gameObject.GetComponent<Transform>().SetParent(this.transform);
			}

			// When you stop holding an interactable, it will continue using gravity and will be detached from the player
			if(holding == false){
				coll.gameObject.GetComponent<Rigidbody>().useGravity = true;
				transform.DetachChildren();
			}
		}

		// If you click on a key, the player will have the key and the gameobject for it will disappear
		if(coll.gameObject.tag == "Key") {
			coll.gameObject.GetComponent<Light>().enabled = true;

			if(Input.GetMouseButtonDown(0)) {
				havekey = true;
				Destroy(coll.gameObject);
			}
		}

		// If you click on a false key, the floor will be destroyed
		if(coll.gameObject.tag == "FalseKey") {
			coll.gameObject.GetComponent<Light>().enabled = true;

			if(Input.GetMouseButtonDown(0)) {
				Destroy(floor);
			}
		}

		// If you have a key to a door and you click on it, the door will move elsewhere
		if(coll.gameObject.tag == "Door" && havekey == true) {
			coll.gameObject.GetComponent<Light>().enabled = true;

			if(Input.GetMouseButtonDown(0)) {
				coll.gameObject.GetComponent<Transform>().position = new Vector3(20,0,0);
			}
		}
	}

	// If the player is no longer in the range of an object, it will stop glowing
	void OnTriggerExit(Collider coll) {
		if(coll.gameObject.tag == "Interactable" && holding == false) {
			coll.gameObject.GetComponent<Light>().enabled = false;
			coll.gameObject.GetComponent<Rigidbody>().useGravity = true;
		}

		if(coll.gameObject.tag == "Key" || coll.gameObject.tag == "FalseKey" || coll.gameObject.tag == "Door") {
			coll.gameObject.GetComponent<Light>().enabled = false;
		}
	}
}
