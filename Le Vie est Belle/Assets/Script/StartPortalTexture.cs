using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPortalTexture : MonoBehaviour {

	public Camera world_1Cam;
	public Material world_1CamMat;

	// Use this for initialization
	void Start () {
		if (world_1Cam.targetTexture != null){

			world_1Cam.targetTexture.Release ();

		}
		world_1Cam.targetTexture = new RenderTexture (Screen.width, Screen.height, 32);
		world_1CamMat.mainTexture = world_1Cam.targetTexture;
	}

}
