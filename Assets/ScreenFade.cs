using UnityEngine;
using System.Collections;

public class ScreenFade : MonoBehaviour {

	public GameObject screenFader;

	public IEnumerator FadeToBlack() {
		for (float f = 1f; f >= 0; f -= 0.01f) {
			Color c = screenFader.GetComponent<SpriteRenderer>().color;
			c.a = f;
			screenFader.GetComponent<SpriteRenderer>().color = c;
			yield return null;
		}
	}

	public IEnumerator FadeFromBlack() {
		for (float f = 0f; f <= 1; f += 0.01f) {
			Color c = screenFader.GetComponent<SpriteRenderer>().color;
			c.a = f;
			screenFader.GetComponent<SpriteRenderer>().color = c;
			yield return null;
		}
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.H))
		   StartCoroutine(FadeFromBlack());
	}
}
