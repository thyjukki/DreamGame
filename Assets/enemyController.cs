using UnityEngine;
using System.Collections;

public class enemyController : MonoBehaviour {

	public float maxSpeed = 5f;
	bool facingRight = false; 
	
	public static bool dreaming = false;
	
	Animator anim;
	Rigidbody2D rb;
	
	bool grounded1 = false;
	bool grounded2 = false;
	bool fullygrounded = false;
	public Transform groundCheck1;
	public Transform groundCheck2;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce =  5;

	private float doWeJump;
	private float doWeMove;
	private float moveDirection = 1;
	public float jumpFrequency = 1; //0-1
	public float moveFrequency = 1; //0-1
	
	
	
	void Start () {
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
	}
	
	
	void FixedUpdate () {

		doWeJump = Random.Range (0.0F, 1.0F);
		doWeMove = Random.Range (0.0F, 1.0F);
		
		//Are we on the ground?
		grounded1 = Physics2D.OverlapCircle (groundCheck1.position, groundRadius, whatIsGround); 
		grounded2 = Physics2D.OverlapCircle (groundCheck2.position, groundRadius, whatIsGround);
		fullygrounded = grounded1 && grounded2;
		anim.SetBool ("Ground", fullygrounded);

		if (grounded1 && !grounded2) { //if on a ledge, turn left. for some reason these are flipped
			moveDirection = 1;
		} else if (!grounded1 && grounded2) { //turn right
			moveDirection = -1;
		}



		//pass vertical speed to animator
		//TODO use this in jump/fall anim
		anim.SetFloat ("vSpeed", rb.velocity.y);


		
		anim.SetFloat ("Speed", Mathf.Abs (doWeMove));

		if (doWeMove <= moveFrequency)
			rb.velocity = new Vector2 (moveDirection * maxSpeed * Mathf.Abs(transform.localScale.x), rb.velocity.y);

		if ((doWeMove > 0 && !facingRight) || (doWeMove < 0 && facingRight))
			Flip ();
	}
	
	void Update(){
		if (fullygrounded && (doWeJump <= jumpFrequency)){

			anim.SetBool("Ground", false);
			rb.velocity = new Vector2(rb.velocity.x, jumpForce*Mathf.Abs(transform.localScale.y));
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
