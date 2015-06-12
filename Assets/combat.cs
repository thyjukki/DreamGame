using UnityEngine;
using System.Collections;

public class combat : MonoBehaviour {

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Enemy" && Input.GetKeyDown ("Hit")) {
			print ("ouch!");
		}
		if (other.tag == "Enemy")
			print ("moi");
	}

}
