using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : MonoBehaviour 
{
	public Camera PlayerCamera;

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown ("Fire1")) 
		{
			Shoot ();
		}
	}

	void Shoot()
	{
		RaycastHit hit;
		if (Physics.Raycast (PlayerCamera.transform.position, PlayerCamera.transform.forward, out hit, GameController._assaultRifleRange))
		{
			Debug.Log (hit.transform.name);
		}
	}
}
