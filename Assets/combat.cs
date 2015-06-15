using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class combat : MonoBehaviour {

	public KeyMapper KeyMapper;

	public Health healthscript;

	private bool Attacking;
	private Animator anim;
	public float bulletSpeed;
	public GameObject ammoPrefab;
	public float fireRate;
	private float lastFireTime;

	private List<Collider2D> enemiesInTriggerArea = new List<Collider2D>();

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Enemy") {

			enemiesInTriggerArea.Add (other);
		}
			
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == "Enemy") {

			enemiesInTriggerArea.Remove (other);
		}

	}
	// TODO: multiple enemies hit? 

	void Start()
	{
		anim = GetComponentInParent<Animator> ();
	}

	void Update()
	{
		if (Input.GetButtonDown ("Hit") && !Attacking) {
			for (int i=0; i<enemiesInTriggerArea.Count; i++){
				Health script = (Health) enemiesInTriggerArea[i].gameObject.GetComponent(typeof(Health));
				script.Damage(5);
			}

			anim.SetTrigger ("Attacking");
			Attacking = true;
		}
		KeyMapper.InputManager shoot = KeyMapper.inputManager.Find (str => string.Equals(str.keyName, "Shoot"));
		if(Input.GetKeyDown(shoot.key.ToLower())) {
			LaunchProjectile();
			lastFireTime = Time.time;
		}

		if(Input.GetKeyDown(shoot.key.ToLower()) && (Time.time > (lastFireTime + fireRate))) {
			LaunchProjectile ();
			lastFireTime = Time.time;
		}
	}

	void LaunchProjectile (){ //launches a projectile of prefab ammoPrefab at speed bulletSpeed
		GameObject ammoObject = (GameObject)Instantiate (ammoPrefab, transform.position, Quaternion.identity);
		Rigidbody2D ammorb = ammoObject.GetComponent<Rigidbody2D> ();
		
		if (HoboController.facingRight == true) {
			ammorb.velocity = (new Vector3 (1.0F, 0.0F, 0.0F) * bulletSpeed);
		} else {
			ammorb.velocity = (new Vector3 (-1.0F, 0.0F, 0.0F) * bulletSpeed);
		}
		
		Destroy (ammoObject, 2.0F);
	}
		
	public void animationEnd()
	{
		Attacking = false;
	}
	
	public void animationAttack()
	{
		//TODO Move attack code here
	}

}
