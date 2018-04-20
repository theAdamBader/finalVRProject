/* REFERENCE
Teleporter: https://youtu.be/cuQao3hEKfs
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script handles the collider for when the player interacts and moves forward into the portal
public class teleportCollider : MonoBehaviour {

	// Creating a variable for a player and a receiver
	public Transform player;
	public Transform receive;

	private bool userIsOverlapping = false;

	// Update is called once per frame
	void Update () {
		if (userIsOverlapping)
		{
			Vector3 portalToThePlayer = player.position - transform.position;
			float dotProduct = Vector3.Dot(transform.up, portalToThePlayer);

			// If this is true then the player moved across the portal
			if (dotProduct < 0f)
			{
				// This calculates the difference between the portals and the player
				// Using quaternion angle is useful for the extension of the complex numbers in rotation
				// Using Euler finds the rotation of degrees around the axis
				// This is used to teleport the player
				float rotationDifference = -Quaternion.Angle(transform.rotation, receive.rotation);
				rotationDifference += 180;
				player.Rotate(Vector3.up, rotationDifference);

				Vector3 offsetPosition = Quaternion.Euler(0f, rotationDifference, 0f) * portalToThePlayer;
				player.position = receive.position + offsetPosition;

				userIsOverlapping = false;
			}
		}
	}

	// When triggered then the player is overlapping = true then moves to the other planet
	// When tiggers is false then it cannot teleport
	void OnTriggerEnter (Collider TeleportToPlayer)
	{
		if (TeleportToPlayer.tag == "Player")
		{
			userIsOverlapping = true;
		}
	}

	void OnTriggerExit (Collider TeleportToPlayer)
	{
		if (TeleportToPlayer.tag == "Player")
		{
			userIsOverlapping = false;
		}
	}
}