using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour 
{

	public enum SpawnState {SPAWNING, WAITING, COUNTING};

	[System.Serializable]
	public class Wave
	{
		public string name;
		public Transform enemyAI;
		public int _aiCount;
		public float _rate;
	}

	public Transform[] spawnPoints;
		
	public Wave[] waves;
	private int nextWave = 0;
	private int waveCounter;

	public float _timeBetweenWaves = 5f;
	public float _waveCountdown;

	private float _searchCountdown = 1f;

	public Text waveCounterText;

	private SpawnState state = SpawnState.COUNTING;

	void Start ()
	{
		_waveCountdown = _timeBetweenWaves;
	}

	void Update ()
	{
		if (state == SpawnState.WAITING)
		{
			if (!EnemyIsALive ())
			{
				StartNewWave ();
			}
			else
			{
				return;
			}
		}

		if (_waveCountdown <= 0)
		{
			if (state != SpawnState.SPAWNING)
			{
				StartCoroutine (SpawnWave (waves [nextWave]));
			}
		}
		else
		{
			_waveCountdown -= Time.deltaTime;
		}
		DisplayText ();
	}

	void StartNewWave()
	{
		state = SpawnState.COUNTING;
		_waveCountdown = _timeBetweenWaves;

		if (nextWave + 1 > waves.Length - 1)
		{
			nextWave = 0;
			Debug.Log ("All Waves Complete");
		}
		else
		{
			nextWave++;
		}
	}

	bool EnemyIsALive()
	{
		_searchCountdown -= Time.deltaTime;
		if (_searchCountdown <= 0f)
		{
			_searchCountdown = 1f;
			if (GameObject.FindGameObjectWithTag ("Zombie") == null)
			{
				return false;
			}
		}

		return true;
	}

	IEnumerator SpawnWave(Wave _wave)
	{
		Debug.Log ("Spawning Wave: " + _wave.name);
		state = SpawnState.SPAWNING;

		for (int i = 0; i < _wave._aiCount; i++)
		{
			SpawnEnemyAI (_wave.enemyAI);
			yield return new WaitForSeconds (1f / _wave._rate);
		}

		state = SpawnState.WAITING;

		yield break;
	}

	void SpawnEnemyAI (Transform _enemy)
	{
		int randomSpawn = Random.Range (0, 3);
		Debug.Log ("Spawning Enemy: " + _enemy.name);
		Instantiate (_enemy, spawnPoints[randomSpawn].position, transform.rotation);

	}

	void DisplayText()
	{
		waveCounter = nextWave + 1;
		waveCounterText.text = "Wave: " + waveCounter;
	}


}











//Brackeys
