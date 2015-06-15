using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public float maxHealth = 5;
	public float currentHealth = 5;
	private bool dead = false;


	void Start()
	{
	}

	public void Damage(float dmg)
	{
		if (dead)
			return;
		currentHealth -= dmg;

		if (currentHealth <= 0)
			Killed();
	}

	private void Killed()
	{
		dead = true;
		ItemDrop itemdropScript = (ItemDrop) GetComponent(typeof(ItemDrop));
		itemdropScript.DropItem ();
		print ("Object Died");
		gameObject.SetActive(false);
	}

}
