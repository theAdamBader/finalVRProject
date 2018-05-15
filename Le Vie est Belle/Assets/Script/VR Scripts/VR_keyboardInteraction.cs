using UnityEngine;
using VRStandardAssets.Utils;

// This script the keyboard functions will work on VR
public class VR_keyboardInteraction : MonoBehaviour
{
	// These would create a field where the developer can input private or protected variables without them being changed 
	[SerializeField] private Material m_NormalMaterial;                
	[SerializeField] private Material m_OverMaterial;                                         
	[SerializeField] private VRInteractiveItem m_InteractiveItem;
	[SerializeField] private Renderer m_Renderer;
	public AudioClip audioFile;
	[SerializeField] private AudioSource m_Audio;
	public Collider box;


	private void Awake ()
	{
		// Start of the game the normal material would with the dev or player changing the material directly onto it
		m_Renderer.material = m_NormalMaterial;
	}


	private void OnEnable()
	{
		// These enable the controller to interacts with the interactable objects
		// Which is called from the VRInput.cs
		m_InteractiveItem.OnOver += HandleOver;
		m_InteractiveItem.OnOut += HandleOut;
		m_InteractiveItem.OnClick += HandleClick;
	}


	private void OnDisable()
	{
		// These disable the controller once it leaves the interactable objects
		m_InteractiveItem.OnOver -= HandleOver;
		m_InteractiveItem.OnOut -= HandleOut;
		m_InteractiveItem.OnClick -= HandleClick;
	}


	// Handle the Over event
	private void HandleOver()
	{
		// When over the interactable object it would change the colour of the material
		m_Renderer.material = m_OverMaterial;

		// When moves hovers over it would turn on the light	
		box.gameObject.GetComponent<Light> ().enabled = true;
	}


	// Handle the Out event
	private void HandleOut()
	{
		// When no longer interacting with the object it would default to the normal material
		m_Renderer.material = m_NormalMaterial;

		// When moves hovers over it would turn off the light	
		box.gameObject.GetComponent<Light> ().enabled = false;
	}


	// Handle the Click event
	private void HandleClick()
	{
		// When clicking on the objects, the audio would play
		m_Audio = GetComponent<AudioSource> ();
		m_Audio.PlayOneShot (audioFile, 0.5f);

	}
}