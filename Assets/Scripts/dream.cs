using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class dream : MonoBehaviour {

	public bool onlyInDream;
	public GameObject dreamVersion;
	bool instantiatedDream = false; //has this object been instantiated in the dream world yet?
	private List<Object> dreamVersionList; //keeps track of instantiated object to make destroying them easy
	GameObject dreamSprite;

	void Start (){
		if (dreamVersion) {
			dreamSprite = (GameObject)Instantiate (dreamVersion, transform.position, Quaternion.identity);
			dreamSprite.GetComponent<SpriteRenderer> ().enabled = false;
			instantiatedDream = true;
		}

		if (onlyInDream && dreamVersion) {
			setReal (false);
		}
		// TODO if invis object in real world, turn collisions off
	}

	void Update () {

		if (HoboController.dreaming == false) {
			if (!onlyInDream)
				setReal(true);
			if (dreamVersion)
			setDream(false);
		}

		if (HoboController.dreaming == true){
			setReal(false);
			if (dreamVersion)
				setDream(true);

			instantiatedDream = false;
		}

	}
	
	void setReal(bool set){
		
		// TODO better way to do this
		
		if (GetComponent<BoxCollider2D> () != null)
			GetComponent<BoxCollider2D> ().enabled = set;
		
		if (GetComponent<SpriteRenderer> () != null)
			GetComponent<SpriteRenderer> ().enabled = set;
		
		if (GetComponent<CircleCollider2D> () != null)
			GetComponent<CircleCollider2D> ().enabled = set;
	}

	void setDream(bool set){

		// TODO better way to do this

		if (dreamSprite.GetComponent<BoxCollider2D> () != null)
			dreamSprite.GetComponent<BoxCollider2D> ().enabled = set;
		
		if (dreamSprite.GetComponent<SpriteRenderer> () != null)
			dreamSprite.GetComponent<SpriteRenderer> ().enabled = set;
		
		if (dreamSprite.GetComponent<CircleCollider2D> () != null)
			dreamSprite.GetComponent<CircleCollider2D> ().enabled = set;
	}
}
