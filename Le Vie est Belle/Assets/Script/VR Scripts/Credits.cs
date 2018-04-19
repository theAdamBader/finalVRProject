using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {

	void OnTriggerEnter(Collider theEnd){
		if (theEnd.tag == "Player") {
			// Load the level
			SceneManager.LoadScene(1);
		}
	}
}
