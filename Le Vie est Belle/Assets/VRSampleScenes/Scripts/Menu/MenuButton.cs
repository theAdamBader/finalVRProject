using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRStandardAssets.Utils;

namespace VRStandardAssets.Menu
{
    // This script is for loading scenes from the main menu.
    // Each 'button' will be a rendering showing the scene
    // that will be loaded and use the SelectionRadial.
    public class MenuButton : MonoBehaviour
    {
        public event Action<MenuButton> OnButtonSelected;                   // This event is triggered when the selection of the button has finished.


        [SerializeField] private string m_SceneToLoad;                      // The name of the scene to load.
        [SerializeField] private VRCameraFade m_CameraFade;                 // This fades the scene out when a new scene is about to be loaded
        [SerializeField] private VRInteractiveItem m_InteractiveItem;       // The interactive item for where the user should click to load the level.


        private bool m_GazeOver;                                            // Whether the user is looking at the VRInteractiveItem currently.


        private void OnEnable ()
        {
            m_InteractiveItem.OnOver += HandleOver;
            m_InteractiveItem.OnOut += HandleOut;

			//Modified Script
			m_InteractiveItem.OnClick += HandleClick;
        }


        private void OnDisable ()
        {
            m_InteractiveItem.OnOver -= HandleOver;
            m_InteractiveItem.OnOut -= HandleOut;

			//Modified Script
			m_InteractiveItem.OnClick += HandleClick;
        }
        

        private void HandleOver()
        {
           
        }


        private void HandleOut()
        {
           
        }



		//Handle the Click event
		private void HandleClick()
		{
			// Load the level
			SceneManager.LoadScene(m_SceneToLoad, LoadSceneMode.Single);

		}


    }
}