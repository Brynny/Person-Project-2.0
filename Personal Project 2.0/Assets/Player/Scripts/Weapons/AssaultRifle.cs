using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : MonoBehaviour 
{
	public Camera PlayerCamera;
	[SerializeField]GameObject Zombie;

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown ("Fire1")) 
		{
			Shoot ();
		}

		LookForZombie ();
	}

	void Shoot()
	{
		RaycastHit hit;
		if (Physics.Raycast (PlayerCamera.transform.position, PlayerCamera.transform.forward, out hit, GameController._assaultRifleRange))
		{
			if (hit.transform.tag == "Zombie")
			{
				Zombie.GetComponent<ZombieController> ().TakeDamage ();
			}
			Debug.Log (hit.transform.tag);
		}
	}

	void LookForZombie()
	{
		Zombie = GameObject.FindGameObjectWithTag ("Zombie");
	}
}
