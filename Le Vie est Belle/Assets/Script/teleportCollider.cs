/* REFERENCE

	- Teleporter: https://youtu.be/cuQao3hEKfs
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportCollider : MonoBehaviour {

	// Creating a variable for a player and a receiver for when the player teleports to the other world

	public Transform player;
	public Transform recieve;

	private bool playerIsOverlapping = false;

	// Update is called once per frame
	void Update () {
		if (playerIsOverlapping)
		{
			Vector3 portalToThePlayer = player.position - transform.position;
			float dotProduct = Vector3.Dot(transform.up, portalToThePlayer);

			// If this is true: The player has moved across the portal
			if (dotProduct < 0f)
			{
				// Teleport him!
				float rotationDifference = -Quaternion.Angle(transform.rotation, recieve.rotation);
				rotationDifference += 180;
				player.Rotate(Vector3.up, rotationDifference);

				Vector3 offsetPosition = Quaternion.Euler(0f, rotationDifference, 0f) * portalToThePlayer;
				player.position = recieve.position + offsetPosition;

				playerIsOverlapping = false;
			}
		}
	}

	void OnTriggerEnter (Collider TeleportToPlayer)
	{
		if (TeleportToPlayer.tag == "Player")
		{
			playerIsOverlapping = true;
		}
	}

	void OnTriggerExit (Collider TeleportToPlayer)
	{
		if (TeleportToPlayer.tag == "Player")
		{
			playerIsOverlapping = false;
		}
	}
}