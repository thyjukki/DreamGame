using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class combat : MonoBehaviour {

	public Health healthscript;

	private bool Attacking;
	private Animator anim;

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

	/*void OnTriggerStay2D (Collider2D other){
		if (other.gameObject.tag == "Enemy" && Input.GetButtonDown ("Hit")){
			Health script = (Health) other.gameObject.GetComponent(typeof(Health));
			script.Damage(5);
		}
	}*/

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
