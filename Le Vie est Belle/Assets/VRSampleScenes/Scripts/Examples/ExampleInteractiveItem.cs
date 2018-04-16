using UnityEngine;
using VRStandardAssets.Utils;

namespace VRStandardAssets.Examples
{
    // This script is a simple example of how an interactive item can
    // be used to change things on gameobjects by handling events.
    public class ExampleInteractiveItem : MonoBehaviour
    {
        [SerializeField] private Material m_NormalMaterial;                
        [SerializeField] private Material m_OverMaterial;                  
        //[SerializeField] private Material m_ClickedMaterial;               
        [SerializeField] private Material m_DoubleClickedMaterial;         
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
            m_InteractiveItem.OnDoubleClick += HandleDoubleClick;
        }


        private void OnDisable()
        {
            m_InteractiveItem.OnOver -= HandleOver;
            m_InteractiveItem.OnOut -= HandleOut;
            m_InteractiveItem.OnClick -= HandleClick;
            m_InteractiveItem.OnDoubleClick -= HandleDoubleClick;
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
			// When moves hovers over it would turn on the light	
			box.gameObject.GetComponent<Light> ().enabled = false;


        }


        //Handle the Click event
        private void HandleClick()
        {
            Debug.Log("Show click state");
			// Mouse pressed then the audio would play
			m_Audio = GetComponent<AudioSource> ();
			m_Audio.PlayOneShot (audioFile, 0.5f);
        }


        //Handle the DoubleClick event
        private void HandleDoubleClick()
        {
            Debug.Log("Show double click");
            m_Renderer.material = m_DoubleClickedMaterial;
        }
    }

}