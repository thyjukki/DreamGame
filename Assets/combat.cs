using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class combat : MonoBehaviour {

	private List<GameObject> enemiesInTriggerArea;

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Enemy" && Input.GetButtonDown("Hit"))
			print ("moi");
	}
	              

}
