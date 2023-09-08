using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTimer : MonoBehaviour {


	public float TeleportTime;
	public float TeleportTotalTimer;
	public bool TeleportIsActive;
	// Use this for initialization
	void Start () {
		TeleportTime = TeleportTotalTimer;
	}
	
	// Update is called once per frame
	void Update () {
		if (TeleportIsActive == true)
		{
			TeleportTime -= Time.deltaTime;
		}
		if(TeleportTime <= 0)
		{
			TeleportTime = TeleportTotalTimer;
			TeleportIsActive= false;
		}
	}
}
