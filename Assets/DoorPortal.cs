using UnityEngine;
using System.Collections;

public class DoorPortal : MonoBehaviour {

	public string levelToLoad;
	GameObject player;

	void Awake (){
		player = GameObject.Find ("Hobo");
		player.GetComponent<BoxCollider2D> ();
	}

	void OnTriggerStay2D(Collider2D other){

		if ((other.GetComponent<BoxCollider2D> () == player.GetComponent<BoxCollider2D> ()) && (Input.GetAxis ("Vertical") > 0.01))
			Application.LoadLevel (levelToLoad);

	}
}
