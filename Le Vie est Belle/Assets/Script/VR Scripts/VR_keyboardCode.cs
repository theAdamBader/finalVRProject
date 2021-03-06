﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

// This script allows the player to input a string of code
public class VR_keyboardCode : MonoBehaviour {

	// Adding a feild to allow the VR Interact know which object to interact with
	[SerializeField] private VRInteractiveItem m_InteractiveItem;

	public AudioClip audioFile;
	AudioSource m_Audio;

	// This 14 character code is what the player must put in, it is the musical note to twinkle twinkle little star
	public static string correctInput = "CCGGAAGFFEEDDC";
	public static string playerInput = "";

	public static int totalDigits = 0;


	void Start(){
		// At the start it would get the audio source for the notes
		m_Audio = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		// If player get all the 14 notes, two of the following thing would run
		// First, if correct then it would destroy the door at the house in the main stage
		// Else returns back to 0 and player would rewrite the code
		if (totalDigits == 14){

			if (playerInput == correctInput)
			{
				Destroy(GameObject.FindWithTag("Door"));
			}

			else {
				playerInput = "";
				totalDigits = 0;
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
		// If player interacts with the game object then it would increase the total digits by one and inserts the name of the object
		// Objects are giving name to match the string
		playerInput += gameObject.name;
		totalDigits ++;

		// If player makes a mistake then they can clear the string and start from 0
		if (gameObject.tag == "Clearing") {
			playerInput = "";
			totalDigits = 0;
		}

		// If player gets the code correct a chime would ring so that they are aware
		if (playerInput == correctInput) {
			m_Audio.PlayOneShot (audioFile, 0.5f);
		}
	}
}