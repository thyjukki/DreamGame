using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class combat : MonoBehaviour {

	/*private List<Collider2D> enemiesInTriggerArea = new List<Collider2D>();
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Enemy") {

			enemiesInTriggerArea.Add (other);
		}
			
	}

	void OnTriggerLeave2D(Collider2D other){
		if (other.gameObject.tag == "Enemy") {

				enemiesInTriggerArea.Remove (other);
		}

	} TODO: multiple enemies hit? */

	void OnTriggerStay2D (Collider2D other){
		if (other.gameObject.tag == "Enemy" && Input.GetButtonDown ("Hit")) {
			print (other.gameObject);
		}
	}


}
