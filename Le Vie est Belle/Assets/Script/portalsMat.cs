using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script handles the texture and material of the rendered camera texture
public class portalsMat : MonoBehaviour {

	public Camera mainWorldCamReturn1;
	public Material mainWorldCamReturn1Mat;

	public Camera world1Cam;
	public Material world1CamMat;

	public Camera mainWorldCamReturn2;
	public Material mainWorldCamReturn2Mat;

	public Camera world2Cam;
	public Material world2CamMat;

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


	if (mainWorldCamReturn2.targetTexture != null){

		mainWorldCamReturn2.targetTexture.Release ();
	}

	mainWorldCamReturn2.targetTexture = new RenderTexture (Screen.width, Screen.height, 24);
	mainWorldCamReturn2Mat.mainTexture = mainWorldCamReturn2.targetTexture;

	if (world2Cam.targetTexture != null){

		world2Cam.targetTexture.Release ();
	}

	world2Cam.targetTexture = new RenderTexture (Screen.width, Screen.height, 24);
	world2CamMat.mainTexture = world2Cam.targetTexture;

}
}