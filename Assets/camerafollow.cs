using UnityEngine;
using System.Collections;

public class camerafollow : MonoBehaviour {

	public GameObject ball;
	Vector3 cameradistance = new Vector3 (0.0F, 10.0F, 0.0F);


	void Update () {
			transform.position = ball.transform.position + cameradistance;

		print (Input.GetAxis ("Mouse ScrollWheel"));
	}
}
