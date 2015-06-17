using UnityEngine;
using System.Collections;

public class levelSwitch : MonoBehaviour {

	public string newLevel;
	
	void OnTriggerStay2D(Collider2D other){
		
		if ((other.name == "Hobo") && (Input.GetAxis ("Vertical") > 0.01)) {
			HoboController.dreaming = true;
			Application.LoadLevel(newLevel);
			
		}
		
	}
}
