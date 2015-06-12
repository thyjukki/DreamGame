using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class combat : MonoBehaviour {

	private List<GameObject> enemiesInTriggerArea;

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Enemy")
			enemiesInTriggerArea.Add (other.gameObject);
			
	}

	void OnTriggerLeave2D(Collider2D other){
		if (other.tag == "Enemy")
			enemiesInTriggerArea.Remove (other.gameObject);

	}

	void Update (){
		if (Input.GetKeyDown ("Hit")) {
			for (int i = 1; i < enemiesInTriggerArea.Length; i++) {
			}
		}
	}

}
