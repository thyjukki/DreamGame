using UnityEngine;
using System.Collections;

public class DreamTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	void OnTriggerEnter(Collider other)  {
		if (other.tag == "Player")
		{
			print ("I am being touched");
			if (Input.GetButtonDown("Sleep"))
			    print ("tosleep");
		}
	}
}
