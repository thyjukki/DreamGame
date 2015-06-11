using UnityEngine;
using System.Collections;

public class inventory : MonoBehaviour {

	public Object[] items; //all items in inventory
	public GameObject[] inventoryPositions; //positions of inventory slots
	private bool inventoryOpen = false;

	void Start () {
	}

	void Update () {
		if (Input.GetAxis ("Inventory") > 0.01)
			inventoryOpen = true;


		if (inventoryOpen) { //if user has pressed I
			for (int i = 0; i < items.Length; i++) { //go through each item in inventory

				Object item = Instantiate (items [i], inventoryPositions [i].transform.position, Quaternion.identity); //and instantiate them at inventory
			}
		}
	}
}
