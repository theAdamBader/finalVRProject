/*
	REFERENCE:
	Keypad inputs (basic) by Game Design HQX: https://youtu.be/o7aC62Nsv-M
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyboardCode : MonoBehaviour {

	public static string correctInput = "CCGGAAGFFEEDDC";
	public static string playerInput = "";

	public static int totalDigits = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (playerInput);
		//Debug.Log ("Unlocked");
		if (totalDigits == 14){
			
			if (playerInput == correctInput)
			{
				Debug.Log ("Unlocked");
				Destroy(GameObject.FindWithTag("Door"));
			}

			else {
				playerInput = "";
				totalDigits = 0;
				Debug.Log ("Try Again");
			}
		}
	}

	void OnMouseDown(){
		playerInput += gameObject.name;
		totalDigits ++;
	}
}
