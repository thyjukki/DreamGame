using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KeyMapper : MonoBehaviour {

	public List<InputManager> inputManager;

	bool change;
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
					inputManager[key].key = e.keyCode.ToString();
					change = false;
				}
			}
		}
	}
}
