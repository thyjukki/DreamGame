using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {
	
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;

	void Update() {
		CharacterController controller = GetComponent<CharacterController>();

		if (controller.isGrounded) {
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Jump"), Input.GetAxis("Vertical"));
                          
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection = moveDirection.normalized;
			print (moveDirection.magnitude);

			moveDirection *= speed * Time.deltaTime;

			/*if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;
			*/
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}
}

