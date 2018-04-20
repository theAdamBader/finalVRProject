using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script handles the texture and material of the rendered camera texture
public class Portal_Material : MonoBehaviour {

	public Camera mainWorldCamReturn1;
	public Material mainWorldCamReturn1Mat;

	public Camera world1Cam;
	public Material world1CamMat;

	// Use this for initialization
	void Start () {

		// If the texture
		if (mainWorldCamReturn1.targetTexture != null){

			mainWorldCamReturn1.targetTexture.Release ();
		}

		mainWorldCamReturn1.targetTexture = new RenderTexture (Screen.width, Screen.height, 24);
		mainWorldCamReturn1Mat.mainTexture = mainWorldCamReturn1.targetTexture;

		if (world1Cam.targetTexture != null){

			world1Cam.targetTexture.Release ();
		}

		world1Cam.targetTexture = new RenderTexture (Screen.width, Screen.height, 24);
		world1CamMat.mainTexture = world1Cam.targetTexture;
	}
}
