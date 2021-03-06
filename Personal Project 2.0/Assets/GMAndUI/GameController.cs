﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour 
{
	public static GameController GC;

	//Player Variables
	public static float _playerMoveSpeed = 5f;
	public static float _playerCurrentHealth;
	public static float _playerMaxHealth = 20f;
	public static float _playerExperience;
	public static float _playerRequiredExperience = 150f;
	public static float _playerLevel = 1f;

	public static float _playerRequiredExperienceRounded;

	//AssaultRifle Variables
	public static float _assaultRifleDamage = 10f;
	public static float _assaultRifleRange = 50f;
	public static float _assaultRifleMaxAmmo = 80f;
	public static float _assaultRifleRemainingAmmo;
	public static float _assaultRifleMagazine = 20f;
	public static float _assaultRifleAmmo;
	public static bool AssaultRifleCanShoot = true;

	//PlasmaGun Variables
	public static float _plasmaGunDamage;

	void Awake()
	{
		GC = this;
	}

	void Start () 
	{
		//AssaultRiffle
		_assaultRifleAmmo = _assaultRifleMagazine;
		_assaultRifleRemainingAmmo = _assaultRifleMaxAmmo;

		_playerCurrentHealth = _playerMaxHealth;
	}
	

	void Update () 
	{
		_playerRequiredExperienceRounded = Mathf.Round (_playerRequiredExperience);

		UpdateLevelUp ();
		AssaultRifle ();
	}

	void UpdateLevelUp()
	{
		if (_playerExperience >= _playerRequiredExperience)
		{
			_playerLevel += 1f;
			_playerExperience = 0f;
			_playerRequiredExperience = _playerRequiredExperience * 1.3f;
		}
	}

	void AssaultRifle()
	{
		if (Input.GetKeyDown (KeyCode.R))
		{
			if (_assaultRifleRemainingAmmo >= _assaultRifleAmmo)
			{
				_assaultRifleRemainingAmmo -= _assaultRifleMagazine;
				_assaultRifleAmmo = _assaultRifleMagazine;
			}
		}

		if (_assaultRifleAmmo <= 0f)
		{
			_assaultRifleAmmo = 0f;
			AssaultRifleCanShoot = false;
		}
		else
			AssaultRifleCanShoot = true;
		
	}
}
