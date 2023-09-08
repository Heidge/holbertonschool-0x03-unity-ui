using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

	TeleportTimer teleportTimer;

	public Transform player;
	public Transform TeleportLocation;
	// Use this for initialization
	void Start()
	{
		teleportTimer = FindObjectOfType<TeleportTimer>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player") && teleportTimer.TeleportTime == teleportTimer.TeleportTotalTimer && teleportTimer.TeleportIsActive == false)
		{
			player.transform.position = TeleportLocation.transform.position;
			teleportTimer.TeleportIsActive = true;
		}
	}
}
