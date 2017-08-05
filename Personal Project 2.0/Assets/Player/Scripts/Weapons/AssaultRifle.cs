using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : MonoBehaviour 
{
	public Camera PlayerCamera;
	[SerializeField]GameObject Zombie;

	[SerializeField]private ParticleSystem GunShotParticles;

	void Update () 
	{
		if (Input.GetButtonDown ("Fire1") && GameController.AssaultRifleCanShoot == true)
		{
			Shoot ();
		}
	}

	void Shoot()
	{
		GunShotParticles.Play ();
		RaycastHit hit;
		if (Physics.Raycast (PlayerCamera.transform.position, PlayerCamera.transform.forward, out hit))
		{
			GameController._assaultRifleAmmo -= 1f;
			if (hit.collider.tag == "Zombie")
			{
				hit.transform.SendMessage ("TakeDamage");
			}
			Debug.Log (hit.transform.tag);
		}
	}
}
