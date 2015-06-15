using UnityEngine;
using System.Collections;

public class dreamSkySwap : MonoBehaviour {

	public Color normalSky;
	public Color dreamSky;

	void Update (){
		if (HoboController.dreaming == true)
			gameObject.GetComponent<Camera> ().backgroundColor = dreamSky;
		else
			gameObject.GetComponent<Camera> ().backgroundColor = normalSky;
	}
}
