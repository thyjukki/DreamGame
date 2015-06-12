using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class combat : MonoBehaviour {

	private List<Collider2D> enemiesInTriggerArea = new List<Collider2D>();

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Enemy") {
			if (!enemiesInTriggerArea.Contains (other))
				enemiesInTriggerArea.Add (other);
		}
			
	}

	void OnTriggerLeave2D(Collider2D other){
		if (other.gameObject.tag == "Enemy") {
			if (enemiesInTriggerArea.Contains (other))
				enemiesInTriggerArea.Remove (other);
		}

	}

	void Update (){
		if (Input.GetButtonDown ("Hit")) {
			for (int i = 1; i < enemiesInTriggerArea.Count; i++) {
				print(enemiesInTriggerArea[i].gameObject);
				print ("anus");
			}
			print ("gay");
		}
	}

}
