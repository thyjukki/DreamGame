using UnityEngine;
using System.Collections;

public class DoorPortal : MonoBehaviour {

	public string levelToLoad;
	GameObject player;

	void OnTriggerStay2D(Collider2D other){

		if ((other.name == "Hobo") && (Input.GetAxis ("Vertical") > 0.01))
			Application.LoadLevel (levelToLoad);

	}
}
