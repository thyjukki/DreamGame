using UnityEngine;
using System.Collections;

public class camerafollow : MonoBehaviour {

	public GameObject target;
	public float cameraDistance = 10.0F;


	void Update () {
		transform.position = Vector3.Lerp (transform.position, target.transform.position + new Vector3 (0.0F, 0F, -10F), 0.1F);

	}
}
