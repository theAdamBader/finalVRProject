/* 
 REFERENCE 
	- Movement: youtube.com/watch?v=Ov9ekwAGhMA
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCamera : MonoBehaviour {

	public enum axisRotation{

		MouseX = 1,
		MouseY = 2

	}

	public axisRotation ax = axisRotation.MouseX;

	float minY = -45.0f;
	float maxY = 45.0f;
	float senHorizontal = 10.0f;
	float senVertical = 10.0f;
	float xRotation = 0;

	// Update is called once per frame
	void Update () {
		if (ax == axisRotation.MouseX) {

			transform.Rotate (0, Input.GetAxis ("Mouse X") * senHorizontal, 0);
		}
		else if(ax == axisRotation.MouseY){

			xRotation -= Input.GetAxis ("Mouse Y") * senVertical;

			// Clamps the vertical angle within the min and max angle given
			xRotation = Mathf.Clamp (xRotation, minY, maxY);

			float yRotation = transform.localEulerAngles.y;

			transform.localEulerAngles = new Vector3 (xRotation, yRotation, 0);
		}
	}
}
