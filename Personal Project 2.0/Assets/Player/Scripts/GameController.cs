using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour 
{
	public static GameController GC;

	public static float _playerMoveSpeed = 5f;

	public static float _playerCurrentHealth;
	public static float _playerMaxHealth = 20f;

	//AssaultRifle Variables
	public static float _assaultRifleDamage = 10f;
	public static float _assaultRifleRange = 50f;

	//PlasmaGun Variables
	public static float _plasmaGunDamage;

	void Awake()
	{
		GC = this;
	}

	void Start () 
	{
		_playerCurrentHealth = _playerMaxHealth;
	}
	

	void Update () 
	{
		
	}
}
