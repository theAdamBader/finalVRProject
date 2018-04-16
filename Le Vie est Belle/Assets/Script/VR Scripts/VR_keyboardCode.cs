/*
	REFERENCE:
	Keypad inputs (basic) by Game Design HQX: https://youtu.be/o7aC62Nsv-M
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class VR_keyboardCode : MonoBehaviour {

	[SerializeField] private VRInteractiveItem m_InteractiveItem;

	public static string correctInput = "CCGGAAGFFEEDDC";
	public static string playerInput = "";

	public static int totalDigits = 0;

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

	private void OnEnable()
	{

		m_InteractiveItem.OnClick += HandleClick;

	}


	private void OnDisable()
	{

		m_InteractiveItem.OnClick -= HandleClick;

	}


	void HandleClick(){
		playerInput += gameObject.name;
		totalDigits ++;
	}
}