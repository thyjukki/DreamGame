using UnityEngine;
using System.Collections;

public class UIManagerScript : MonoBehaviour {
	
	public Animator startButton;
	public Animator settingsButton;

	public void OpenSettings()
	{
		startButton.SetBool("isHidden", true);
		settingsButton.SetBool("isHidden", true);
	}

	public void StartGame()
	{
		Application.LoadLevel("CubeFall");
	}
}