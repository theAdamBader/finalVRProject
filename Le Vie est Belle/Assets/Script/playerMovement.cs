/* 
 REFERENCE 
	- Movement: youtube.com/watch?v=Ov9ekwAGhMA
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

	float speed = 5.0f;
	float grav = -9.0f;

	private CharacterController playerCont;

	// Use this for initialization
	void Start(){

		playerCont = GetComponent<CharacterController> ();
	}

	// Update is called once per frame
	void Update(){

		float xDelta = Input.GetAxis ("Horizontal") * speed;
		float zDelta = Input.GetAxis ("Vertical") * speed;
		Vector3 playerMove = new Vector3 (xDelta, 0, zDelta);
		playerMove = Vector3.ClampMagnitude (playerMove, speed);

		//playerMove.y = grav;

		// Ensures that the speed of the player does not change every frame
		playerMove *= Time.deltaTime;
		playerMove = transform.TransformDirection (playerMove);
		playerCont.Move (playerMove);
	}
}
