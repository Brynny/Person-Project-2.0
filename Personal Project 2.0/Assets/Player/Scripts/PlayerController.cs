using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	//public float moveSpeed;
	private Rigidbody myRB;

	private Vector3 moveInput;
	private Vector3 moveVelocity;

	private Camera mainCamera;


	void Start ()
	{
		myRB = GetComponent<Rigidbody>();
		mainCamera = FindObjectOfType<Camera>();
	}


	void Update () 
	{

	}

	void FixedUpdate()
	{
		Movement();
	}

	void Movement()
	{
		moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
		moveVelocity = moveInput * GameController._playerMoveSpeed;

		myRB.velocity = moveVelocity;

		Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
		float rayLength;

		if (groundPlane.Raycast(cameraRay, out rayLength))
		{
			Vector3 pointToLook = cameraRay.GetPoint(rayLength);
			Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

			transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
		}
	}

}