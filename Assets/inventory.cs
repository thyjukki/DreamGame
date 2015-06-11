using UnityEngine;
using System.Collections;

public class inventory : MonoBehaviour {

	public GameObject[] items; //items in inventory
	public Vector3[] inventoryPositions; //positions of inventory slots

	void Start () {
	}

	void Update () {
		for (int i = 0; i < items.Length; i++) {
			Instantiate (items [i], inventoryPositions [i], Quaternion.identity);
		}
	}
}
