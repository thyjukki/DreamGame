using UnityEngine;
using System.Collections;

public class ItemDrop : MonoBehaviour {
	public GameObject itemToDrop;
	GameObject item;

	public void DropItem(){
		item = (GameObject)Instantiate (itemToDrop, transform.position, Quaternion.identity);
		item.tag = "Pickup";
		item.GetComponent<Rigidbody2D> ().isKinematic = false;
		item.GetComponent<Rigidbody2D> ().gravityScale = 1;
		item.GetComponent<SpriteRenderer> ().sortingLayerName = "Enemy";

		if (item.GetComponent<CircleCollider2D> () != null)
			item.GetComponent<CircleCollider2D> ().isTrigger = true;
		if (item.GetComponent<BoxCollider2D> () != null)
			item.GetComponent<BoxCollider2D> ().isTrigger = true;

	}

	void OnTriggerEnter2D(Collider2D other){
		print ("other");
		if (other.tag == "Ground") {
			print ("ground");
			item.GetComponent<Rigidbody2D> ().gravityScale = 0;
			item.GetComponent<Rigidbody2D> ().isKinematic = true;
			
			if (item.GetComponent<CircleCollider2D> () != null)
				item.GetComponent<CircleCollider2D> ().isTrigger = false;
			if (item.GetComponent<BoxCollider2D> () != null)
				item.GetComponent<BoxCollider2D> ().isTrigger = false;
		}
	}
}
