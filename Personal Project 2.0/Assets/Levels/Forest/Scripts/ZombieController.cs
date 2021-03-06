﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
	public Transform target;
	public GameObject zombie;

	[SerializeField]private ParticleSystem Blood;
	//[SerializeField]private Transform BloodLocation;

	[SerializeField]private float _zombieHealth = 50f;

	private UnityEngine.AI.NavMeshAgent agent;

	void Awake()
	{
		target = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void Start () 
	{
		agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
	}

	void Update () 
	{
		MoveToPlayer ();
	}

	public void MoveToPlayer()
	{
		agent.SetDestination(target.position);
	}

	public void TakeDamage()
	{
		_zombieHealth -= GameController._assaultRifleDamage;
		if (_zombieHealth <= 0)
		{
			Die ();
		}
		Blood.Play ();
	}

	void Die()
	{
		GameController._playerExperience += 12f;
		Destroy (this.gameObject);
	}
}
