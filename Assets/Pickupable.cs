using UnityEngine;
using System.Collections;

public class Pickupable : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Ground") {
			GetComponent<Rigidbody2D> ().gravityScale = 0;
			GetComponent<Rigidbody2D> ().isKinematic = true;
			
			if (GetComponent<CircleCollider2D> () != null)
				GetComponent<CircleCollider2D> ().isTrigger = false;
			if (GetComponent<BoxCollider2D> () != null)
				GetComponent<BoxCollider2D> ().isTrigger = false;
		}
	}

	void Update(){
		if (GetComponent<CircleCollider2D> () != null) {
			if (GetComponent<CircleCollider2D> ().IsTouching (GameObject.Find ("Hobo").GetComponent<BoxCollider2D>()) == true) {
				inventory inventoryScript = (inventory)GameObject.Find ("Main Camera").GetComponent (typeof(inventory));
				inventoryScript.items.Add (gameObject.name);
				Destroy(gameObject);

			}
		}

		if (GetComponent<BoxCollider2D> () != null) {
			if (GetComponent<BoxCollider2D> ().IsTouching (GameObject.Find ("Hobo").GetComponent<BoxCollider2D>()) == true) {
				inventory inventoryScript = (inventory)GameObject.Find ("Main Camera").GetComponent (typeof(inventory));
				inventoryScript.items.Add (gameObject.name);
				Destroy (gameObject);
			}
		}
	}
}
