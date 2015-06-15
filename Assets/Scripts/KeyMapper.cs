using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KeyMapper : MonoBehaviour {

	public List<InputManager> inputManager;

	bool change;
	bool test;
	int key;

	[System.Serializable]
	public class InputManager
	{
		public string keyName;
		public string key;
	}

	void OnGUI()
	{
		Event e = Event.current;

		if (inputManager != null)
		{
			for (int i = 0; i < inputManager.Count; i++)
			{
				GUILayout.BeginHorizontal();

				GUILayout.Label(inputManager[i].keyName);

				if (GUILayout.Button(inputManager[i].key))
				{
					key = i;
					change = true;
				}

				GUILayout.EndHorizontal();

				if (change && e.isKey)
				{
					//Fix the control/ctrl issue
					if (e.keyCode.ToString () == "LeftControl")
					{
						inputManager[key].key = "left ctrl";
						PlayerPrefs.SetString (inputManager[key].keyName, "left ctrl");
					}
					else if (e.keyCode.ToString() == "RightControl")
					{
						inputManager[key].key = "right ctrl";
						PlayerPrefs.SetString (inputManager[key].keyName, "right ctrl");

					}
					else if (e.keyCode.ToString() == "UpArrow")
					{
						inputManager[key].key = "up";
						PlayerPrefs.SetString (inputManager[key].keyName, "up");
						
					}
					else if (e.keyCode.ToString() == "DownArrow")
					{
						inputManager[key].key = "down";
						PlayerPrefs.SetString (inputManager[key].keyName, "down");
						
					}
					else if (e.keyCode.ToString() == "LeftArrow")
					{
						inputManager[key].key = "left";
						PlayerPrefs.SetString (inputManager[key].keyName, "left");
						
					}
					else if (e.keyCode.ToString() == "RightArrow")
					{
						inputManager[key].key = "right";
						PlayerPrefs.SetString (inputManager[key].keyName, "right");
						
					}
					else
					{
						inputManager[key].key = e.keyCode.ToString();
						PlayerPrefs.SetString(inputManager[key].keyName, e.keyCode.ToString());
					}
					change = false;
				}
			}

			if (GUILayout.Button("Test Button"))
				test = true;
		}
	}

	void Start()
	{
		for(int i = 0; i< inputManager.Count; i++)
		{
			inputManager[i].key = PlayerPrefs.GetString(inputManager[i].keyName);
		}
	}

	void FixedUpdate()
	{
		if (test)
		{

			InputManager jump = inputManager.Find (str => string.Equals(str.keyName, "Jump"));

			if(Input.GetKeyDown(jump.key.ToLower()))
				print (jump.keyName);

			InputManager shoot = inputManager.Find (str => string.Equals(str.keyName, "Shoot"));
			
			if(Input.GetKeyDown(shoot.key.ToLower()))
				print (shoot.keyName);
		}
	}
}
