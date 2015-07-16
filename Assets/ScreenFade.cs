using UnityEngine;
using System.Collections;

public class ScreenFade : MonoBehaviour {

	public GameObject screenFader;
	private string currentlyRunning = "none";

	public IEnumerator FadeFromBlack() {
		currentlyRunning = "FadeFromBlack";
		for (float f = 1f; f >= 0; f -= 0.01f) {
			Color c = screenFader.GetComponent<SpriteRenderer>().color;
			c.a = f;
			screenFader.GetComponent<SpriteRenderer>().color = c;
			yield return null;
		}
		currentlyRunning = "none";
	}

	public IEnumerator FadeToBlack() {
		currentlyRunning = "FadeToBlack";
		for (float f = 0f; f <= 1; f += 0.01f) {
			Color c = screenFader.GetComponent<SpriteRenderer>().color;
			c.a = f;
			screenFader.GetComponent<SpriteRenderer>().color = c;
			yield return null;
		}
		currentlyRunning = "none";
		StartCoroutine (FadeFromBlack());
	}


	void Update(){
		if (Input.GetKeyDown (KeyCode.H)) {
			if ((currentlyRunning == "none" && screenFader.GetComponent<SpriteRenderer>().color.a < 0.01) || currentlyRunning == "FadeFromBlack") {
				StopCoroutine (FadeFromBlack ());
				StartCoroutine (FadeToBlack ());
			}else{
				StopCoroutine(FadeToBlack());
				StartCoroutine(FadeFromBlack());
			}
		}
	}
}
