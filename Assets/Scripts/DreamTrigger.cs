using UnityEngine;
using System.Collections;

public class DreamTrigger : MonoBehaviour {

	public float destinationX;

	void OnTriggerStay2D(Collider2D other){
		
		if ((other.name == "Hobo") && (Input.GetAxis ("Vertical") > 0.01)) {
			other.gameObject.transform.position = new Vector2 (destinationX, 2f);
			GameObject.Find ("Main Camera").transform.position = new Vector3 (destinationX, 3f, GameObject.Find ("Main Camera").transform.position.z);

			HoboController.dreaming = true;

		}
	
	}

}
