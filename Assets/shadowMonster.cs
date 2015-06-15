using UnityEngine;
using System.Collections;

public class shadowMonster : MonoBehaviour {

	void Start () {
		gameObject.GetComponent<SpriteRenderer>().enabled = false;
		gameObject.GetComponent<BoxCollider2D> ().enabled = false;
		gameObject.GetComponent<Rigidbody2D> ().gravityScale = 0;
	}

	void Update () {
		if (HoboController.dreaming == true) {
			gameObject.GetComponent<SpriteRenderer>().enabled = true;
			gameObject.GetComponent<BoxCollider2D> ().enabled = true;
			gameObject.GetComponent<Rigidbody2D> ().gravityScale = 1;
		} else {
			gameObject.GetComponent<SpriteRenderer>().enabled = false;
			gameObject.GetComponent<BoxCollider2D> ().enabled = false;
			gameObject.GetComponent<Rigidbody2D> ().gravityScale = 0;
		}
	}
}
