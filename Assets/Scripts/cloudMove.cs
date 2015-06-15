using UnityEngine;
using System.Collections;

public class cloudMove : MonoBehaviour {

	public float cloudSpeed;
	public float startx;
	public float endx;


	void Awake (){
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (cloudSpeed, 0f);

	}

	void Update (){
		if (gameObject.transform.position.x > endx)
			gameObject.transform.position = new Vector2(startx, gameObject.transform.position.y);
	}
}
