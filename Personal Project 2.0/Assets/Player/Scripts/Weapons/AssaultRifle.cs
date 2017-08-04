using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : MonoBehaviour 
{
	public Camera PlayerCamera;
	[SerializeField]GameObject Zombie;

	[SerializeField]private GameObject GunShotParticle;
	[SerializeField]private Transform GunShotParticleLocation;



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
		if (Physics.Raycast (PlayerCamera.transform.position, PlayerCamera.transform.forward, out hit))
		{
			if (hit.collider.tag == "Zombie")
			{
				hit.transform.SendMessage ("TakeDamage");
			}
			Debug.Log (hit.transform.tag);
		}
		Instantiate (GunShotParticle, GunShotParticleLocation.position, GunShotParticleLocation.rotation);
	}
}
