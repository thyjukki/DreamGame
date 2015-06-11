using UnityEngine;
using System.Collections;

public class toggleDreamObject : MonoBehaviour {

	public void toggle(){
		if (GetComponent<BoxCollider2D> () != null)
			GetComponent<BoxCollider2D> ().enabled = !GetComponent<BoxCollider2D> ().enabled;

		if (GetComponent<SpriteRenderer> () != null)
			GetComponent<SpriteRenderer> ().enabled = !GetComponent<SpriteRenderer> ().enabled;
		
		if (GetComponent<CircleCollider2D> () != null)
			GetComponent<CircleCollider2D> ().enabled = !GetComponent<CircleCollider2D> ().enabled;
	
	}
}
