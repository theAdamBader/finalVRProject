using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraPortal2 : MonoBehaviour {

	[SerializeField] private Transform playerCam;
	[SerializeField] private Transform portalStart;
	[SerializeField] private Transform portalEnd;

	// Update is called once per frame
	void Update () {

		Vector3 playerOffsetFromPortal = playerCam.position - portalEnd.position;
		transform.position = portalStart.position + playerOffsetFromPortal;

		// It is to allow the portal camera to rotate as the player rotates around
		float angularDifferenceBetweenPortalRotation = Quaternion.Angle(portalStart.rotation, portalEnd.rotation);

		Quaternion DifferenceBetweenPortalRotation = Quaternion.AngleAxis (angularDifferenceBetweenPortalRotation, Vector3.up);
		Vector3 newCameraDir = DifferenceBetweenPortalRotation * playerCam.forward;
		transform.rotation = Quaternion.LookRotation (newCameraDir, Vector3.up);
	}
}
