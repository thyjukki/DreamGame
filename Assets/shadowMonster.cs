using UnityEngine;
using System.Collections;

public class shadowMonster : MonoBehaviour {

	void Start () {
		enabled = false;
	}

	void Update () {
		if (HoboController.dreaming = true) {
			enabled = true;
		} else {
			enabled = false;
		}
	}
}
