/*
	REFERENCE
	-VR Sample (Example Interaction.cs): https://assetstore.unity.com/packages/essentials/tutorial-projects/vr-samples-51519
*/

using UnityEngine;
using VRStandardAssets.Utils;

namespace VRStandardAssets.Examples
{
	// This script how to interactive with the keyboard functions
	public class VR_keyboardInteraction : MonoBehaviour
	{
		[SerializeField] private Material m_NormalMaterial;                
		[SerializeField] private Material m_OverMaterial;                                         
		[SerializeField] private VRInteractiveItem m_InteractiveItem;
		[SerializeField] private Renderer m_Renderer;
		public AudioClip audioFile;
		[SerializeField] private AudioSource m_Audio;
		public Collider box;


		private void Awake ()
		{
			m_Renderer.material = m_NormalMaterial;
		}


		private void OnEnable()
		{
			m_InteractiveItem.OnOver += HandleOver;
			m_InteractiveItem.OnOut += HandleOut;
			m_InteractiveItem.OnClick += HandleClick;

		}


		private void OnDisable()
		{
			m_InteractiveItem.OnOver -= HandleOver;
			m_InteractiveItem.OnOut -= HandleOut;
			m_InteractiveItem.OnClick -= HandleClick;
		}


		//Handle the Over event
		private void HandleOver()
		{
			Debug.Log("Show over state");
			m_Renderer.material = m_OverMaterial;
			// When moves hovers over it would turn on the light	
			box.gameObject.GetComponent<Light> ().enabled = true;
		}


		//Handle the Out event
		private void HandleOut()
		{
			Debug.Log("Show out state");
			m_Renderer.material = m_NormalMaterial;
			// When moves hovers over it would turn off the light	
			box.gameObject.GetComponent<Light> ().enabled = false;


		}


		//Handle the Click event
		private void HandleClick()
		{
			// Mouse pressed then the audio would play
			m_Audio = GetComponent<AudioSource> ();
			m_Audio.PlayOneShot (audioFile, 0.5f);
		}
	}
}