using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class inventory : MonoBehaviour {

	public KeyMapper KeyMapper;

	public float itemSize;
	public List<string> items = new List<string>(); //holds list of items in inventory
	public List<GameObject> inventoryPositions = new List<GameObject>(); //positions of inventory slots
	private bool inventoryOpen = false;
	private List<GameObject> instantiatedItems = new List<GameObject>();

	void Start () {

	}

	void Update () {
		//if list is open and I is pressed
		//KeyMapper.InputManager inventoryKeyMapper = KeyMapper.inputManager.Find (str => string.Equals(str.keyName, "Inventory"));
		if(Input.GetButtonDown("Inventory") && inventoryOpen) {
			inventoryOpen = !inventoryOpen;
			EmptyList();
		
		//if list if not open and I is pressed
		}else if (Input.GetButtonDown ("Inventory") && !inventoryOpen) {
			inventoryOpen = !inventoryOpen;
			for (int i = 0; i < items.Count; i++) { //go through each item in inventory
				//and instantiate them inventory positions
				print (items[i].Replace("(Clone)", ""));
				GameObject item = (GameObject) Instantiate (Assets.Load(items[i].Replace("(Clone)", ""), typeof(GameObject)), inventoryPositions [i].transform.position, Quaternion.identity);

				//scale item to itemSize
				item.transform.localScale = new Vector3(itemSize, itemSize, item.transform.localScale.z);
				//set item's sorting layer to UI so it renders in front
				item.GetComponent<SpriteRenderer>().sortingLayerName = "UI";

				//set colliders off
				if (item.GetComponent<BoxCollider2D> () != null)
					item.GetComponent<BoxCollider2D> ().enabled = false;
				if (item.GetComponent<CircleCollider2D> () != null)
					item.GetComponent<CircleCollider2D> ().enabled = false;

				//add item to list of instantiated items
				instantiatedItems.Add(item);
				
			}
			
		}

		if (inventoryOpen) {
			for (int i = 0; i < instantiatedItems.Count; i++) {
				instantiatedItems[i].transform.position = inventoryPositions[i].transform.position;
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
