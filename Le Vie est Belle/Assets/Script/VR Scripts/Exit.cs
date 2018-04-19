using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRStandardAssets.Utils;

	
	public class Exit : MonoBehaviour
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

		//Handle the Click event
		private void HandleClick()
		{
			// Load the level
			Application.Quit();

		}
	}