using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class dream : MonoBehaviour {

	public GameObject dreamVersion;
	bool instantiatedDream = false; //has this object been instantiated in the dream world yet?
	private List<Object> dreamVersionList; //keeps track of instantiated object to make destroying them easy
	GameObject dreamSprite;

	void Start (){
		dreamSprite = (GameObject)Instantiate (dreamVersion, transform.position, Quaternion.identity);
		dreamSprite.GetComponent<SpriteRenderer> ().enabled = false;

	}

	void Update () {

		if (HoboController.dreaming == true && instantiatedDream == false) {
			toggleComponents();

			instantiatedDream = true;
		}

		if (HoboController.dreaming == false && instantiatedDream == true){
			toggleComponents();

			instantiatedDream = false;
		}

	}

	void toggleComponents(){

		// TODO better way to do this

		if (GetComponent<BoxCollider2D> () != null)
			GetComponent<BoxCollider2D> ().enabled = !GetComponent<BoxCollider2D> ().enabled;

		if (GetComponent<SpriteRenderer> () != null)
			GetComponent<SpriteRenderer> ().enabled = !GetComponent<SpriteRenderer> ().enabled;
		
		if (GetComponent<CircleCollider2D> () != null)
			GetComponent<CircleCollider2D> ().enabled = !GetComponent<CircleCollider2D> ().enabled;

		if (dreamSprite.GetComponent<BoxCollider2D> () != null)
			dreamSprite.GetComponent<BoxCollider2D> ().enabled = !GetComponent<BoxCollider2D> ().enabled;
		
		if (dreamSprite.GetComponent<SpriteRenderer> () != null)
			dreamSprite.GetComponent<SpriteRenderer> ().enabled = !GetComponent<SpriteRenderer> ().enabled;
		
		if (dreamSprite.GetComponent<CircleCollider2D> () != null)
			dreamSprite.GetComponent<CircleCollider2D> ().enabled = !GetComponent<CircleCollider2D> ().enabled;
	}
}
