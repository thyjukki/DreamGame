using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public float maxHealth = 5;
	public float curHealth = 5;
	private bool playerDead = false;


	void Start()
	{
	}

	public void Damage(float dmg)
	{
		if (playerDead)
			return;
		curHealth -= dmg;

		if (curHealth <= 0)
			playerKilled();
	}

	void playerKilled()
	{
		playerDead = true;

		print ("Player Died");
	}

}
