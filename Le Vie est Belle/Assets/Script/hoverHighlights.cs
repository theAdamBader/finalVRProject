/*
	REFERENCE:
	Change Color on mouse over by Katus Production: https://youtu.be/VHeem-mywDk
	Audio Source on Unity Docs: https://docs.unity3d.com/ScriptReference/AudioSource.PlayOneShot.html
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoverHighlights : MonoBehaviour {

	public AudioClip audioFile;
	AudioSource myAudioClip;
	public Collider box;


	void OnMouseEnter()
	{
		// When moves hovers over it would turn on the light	
		box.gameObject.GetComponent<Light> ().enabled = true;

	}

	void OnMouseExit()
	{
		// When moves hovers out it would turn off the light	
		box.gameObject.GetComponent<Light> ().enabled = false;

	}

	void OnMouseDown()
	{
		// Mouse pressed then the audio would play
		myAudioClip = GetComponent<AudioSource> ();
		myAudioClip.PlayOneShot (audioFile, 0.5f);
	}   
}