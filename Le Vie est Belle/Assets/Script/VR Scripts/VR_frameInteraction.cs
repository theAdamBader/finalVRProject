using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class VR_frameInteraction : MonoBehaviour {

	[SerializeField] private Material m_NormalMaterial;                
	[SerializeField] private Material m_OverMaterial;   
	[SerializeField] private VRInteractiveItem m_InteractiveItem;
	[SerializeField] private Renderer m_Renderer;


	private void Awake ()
	{
		// Start of the game the normal material would with the dev or player changing the material directly onto it
		m_Renderer.material = m_NormalMaterial;
	}


	private void OnEnable()
	{
		// These enable the controller or HMD to interacts with the interactable objects
		// Which is called from the VRInput.cs
		m_InteractiveItem.OnOver += HandleOver;
		m_InteractiveItem.OnOut += HandleOut;
	}


	private void OnDisable()
	{
		// These disable the controller or HMD once it leaves the interactable objects
		m_InteractiveItem.OnOver -= HandleOver;
		m_InteractiveItem.OnOut -= HandleOut;
	}


	// Handle the Over event
	private void HandleOver()
	{
		// When over the interactable object it would change the colour of the material
		m_Renderer.material = m_OverMaterial;
	}


	// Handle the Out event
	private void HandleOut()
	{
		// When no longer interacting with the object it would default to the normal material
		m_Renderer.material = m_NormalMaterial;
	}
}