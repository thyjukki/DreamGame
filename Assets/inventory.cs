using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class inventory : MonoBehaviour {

	public float itemSize;
	public List<Object> items = new List<Object>(); //holds list of items in inventory
	public List<GameObject> inventoryPositions = new List<GameObject>(); //positions of inventory slots
	private bool inventoryOpen = false;
	private List<GameObject> instantiatedItems = new List<GameObject>();

	void Start () {
	}

	void Update () {
		//if list is open and I is pressed
		if (Input.GetButtonDown ("Inventory") && inventoryOpen) {
			inventoryOpen = !inventoryOpen;
			EmptyList();
		
		//if list if not open and I is pressed
		}else if (Input.GetButtonDown ("Inventory") && !inventoryOpen) {
			inventoryOpen = !inventoryOpen;
			for (int i = 0; i < items.Count; i++) { //go through each item in inventory
				//and instantiate them inventory positions
				GameObject item = (GameObject) Instantiate (items [i], inventoryPositions [i].transform.position, Quaternion.identity);
				//set item as child of Hobo so they follow him
				item.transform.parent = transform;
				//scale item to half size
				item.transform.localScale = new Vector3(itemSize, itemSize, item.transform.localScale.z);
				//set item's sorting layer to UI so it renders in front
				item.GetComponent<SpriteRenderer>().sortingLayerName = "UI";
				//add item to list of instantiated items
				instantiatedItems.Add(item);
				
			}
			
		}
	}

	void EmptyList (){
		for (int i = 0; i < instantiatedItems.Count; i++) {
			//destroy instantiated item
			DestroyImmediate (instantiatedItems [i]);
		}
		//clear list of instantiated items
		instantiatedItems.Clear();

	}
}
