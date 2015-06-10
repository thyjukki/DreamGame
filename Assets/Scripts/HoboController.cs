using UnityEngine;
using System.Collections;

public class HoboController : MonoBehaviour {

	public float maxSpeed = 10f;
	bool facingRight = false; 

	Animator anim;
	Rigidbody2D rb;

	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce =  700f;



	void Start () {
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
	}
	

	void FixedUpdate () {

		//Are we on the ground?
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);

		//pass vertical speed to animator
		anim.SetFloat ("vSpeed", rb.velocity.y);


		float move = Input.GetAxis ("Horizontal");

		anim.SetFloat ("Speed", Mathf.Abs (move));

		Rigidbody2D body = GetComponent<Rigidbody2D> ();
		rb.velocity = new Vector2 (move * maxSpeed, rb.velocity.y);

		if ((move > 0 && !facingRight) || (move < 0 && facingRight))
			Flip ();
	}

	void Update(){
		if (grounded && (Input.GetAxis("Jump") > 0.01)){
			anim.SetBool("Ground", false);
			rb.velocity = new Vector2(rb.velocity.x, jumpForce);
		}
	}


	// Flips the character
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
