using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camMove : MonoBehaviour {
	public float cspeed = 2.0f;   // The speed the camera moves at
	public float h = 0.0f;         // The horizontal position of the camera
	public float v = 0.0f;         // The vertical position of the camera
	//public GameObject floor;       // The floor game object, edit in the Inspector

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

}
