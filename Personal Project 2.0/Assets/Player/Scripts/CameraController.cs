using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	public Transform player;
	public float distance = 20f;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		//transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z - distance);

		Vector3 playerPosition = GameObject.Find("Player").transform.transform.position;
		GameObject.Find("Main Camera").transform.position = new Vector3(playerPosition.x, playerPosition.y + distance, playerPosition.z);
	}
}
