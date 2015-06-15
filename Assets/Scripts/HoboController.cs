using UnityEngine;
using System.Collections;

public class HoboController : MonoBehaviour {

	public KeyMapper KeyMapper;

	public float maxSpeed = 5f;
	public static bool facingRight; 

	public static bool dreaming;

	Animator anim;
	Rigidbody2D rb;

	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.1f;
	public LayerMask whatIsGround;
	public float jumpForce =  5;
	combat combatScript;



	void Start () {
		combatScript = (combat) GetComponentInChildren(typeof(combat));
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();

		facingRight = false;
		dreaming = false;


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
		rb.velocity = new Vector2 (move * maxSpeed*Mathf.Abs(transform.localScale.x), rb.velocity.y);

		if ((move > 0 && !facingRight) || (move < 0 && facingRight))
			Flip ();
	}

	void Update(){
		if (grounded && (Input.GetAxis("Jump") > 0.01)){
			anim.SetBool("Ground", false);
			rb.velocity = new Vector2(rb.velocity.x, jumpForce*Mathf.Abs(transform.localScale.y));
		}

		KeyMapper.InputManager sleep = KeyMapper.inputManager.Find(str => string.Equals(str.keyName, "Sleep"));
		if(Input.GetKeyDown(sleep.key.ToLower())) {
			dreaming = !dreaming;
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
	
	void AttackEnd()
	{
		combatScript.animationEnd ();
	}
	
	void Attack()
	{
		combatScript.animationAttack ();
	}
}
