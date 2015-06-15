using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {

	public KeyMapper KeyMapper;
	
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	private Vector2 moveDirection = Vector2.zero;
	public static bool dreaming;
	
	void Update() {



		CharacterController controller = GetComponent<CharacterController>();

		// Init intial move vector
		moveDirection = new Vector2(Input.GetAxis("Horizontal"), 0.0F);

		
		//moveDirection = transform.TransformDirection(moveDirection);
		moveDirection = moveDirection.normalized;
		//print (moveDirection.magnitude);
		
		moveDirection *= speed * Time.deltaTime;
		

		//check if we are grounded so we can jump
		KeyMapper.InputManager jump = KeyMapper.inputManager.Find (str => string.Equals(str.keyName, "Jump"));
		if (controller.isGrounded) {
			if(Input.GetKey(jump.key.ToLower()))
				moveDirection += new Vector2(0,jumpSpeed);
		}
		/*if (Input.GetButton("Jump"))
			moveDirection.y = jumpSpeed;
		*/

		//moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);


		
	}

	void Start() {
		Physics.gravity = new Vector3(0, -1.0F, 0);
	}
}
