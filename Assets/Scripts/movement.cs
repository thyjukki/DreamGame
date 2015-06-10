﻿using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {
	
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;

	void Update() {
		Rigidbody2D controller = GetComponent<Rigidbody2D>();

		moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Jump"), Input.GetAxis("Vertical"));
                      
		//moveDirection = transform.TransformDirection(moveDirection);
		moveDirection = moveDirection.normalized;
		//print (moveDirection.magnitude);

		moveDirection *= speed * Time.deltaTime;

		/*if (Input.GetButton("Jump"))
			moveDirection.y = jumpSpeed;
		*/
		if(moveDirection.magnitude != 0)
			transform.LookAt(transform.position + moveDirection);
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);

	}
}

