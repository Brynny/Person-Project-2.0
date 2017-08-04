using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShotParticle : MonoBehaviour 
{
	[SerializeField]float timer = 0.1f;

	void start ()
	{
		
	}

	void Update()
	{
		timer -= Time.deltaTime;

		if (timer <= 0f)
			Destroy (this.gameObject);
	}
}
