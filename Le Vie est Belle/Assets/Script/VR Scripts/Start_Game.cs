using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRStandardAssets.Utils;

// This script handles the action for the player to start the game
public class Start_Game : MonoBehaviour
{

	[SerializeField] private VRCameraFade m_CameraFade;                 // This fades the scene out when a new scene is about to be loaded
	[SerializeField] private VRInteractiveItem m_InteractiveItem;       // The interactive item for where the user should click to load the level.


	private void OnEnable ()
	{
		m_InteractiveItem.OnClick += HandleClick;
	}


	private void OnDisable ()
	{
		m_InteractiveItem.OnClick += HandleClick;
	}
		
	private void HandleClick()
	{
		// Loads the main level
		SceneManager.LoadScene(1);
	}
}