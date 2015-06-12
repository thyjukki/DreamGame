using UnityEngine;
using System.Collections;

public class DestroyOnCollision : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag != "Player" && other.gameObject.tag != "Check") {
			Destroy (gameObject);
		}
	}
}
