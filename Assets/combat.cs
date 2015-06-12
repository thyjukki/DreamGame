using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class combat : MonoBehaviour {

	private List<GameObject> enemiesInTriggerArea = new List<GameObject>();

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Enemy")
			enemiesInTriggerArea.Add (other.gameObject);
			
	}

	void OnTriggerLeave2D(Collider2D other){
		if (other.tag == "Enemy")
			enemiesInTriggerArea.Remove (other.gameObject);

	}

	void Update (){
		if (Input.GetButtonDown ("Hit")) {
			for (int i = 1; i < enemiesInTriggerArea.Count; i++) {
				print(enemiesInTriggerArea[i]);
			}
		}
	}

}
