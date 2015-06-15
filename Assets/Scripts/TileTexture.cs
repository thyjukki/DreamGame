using UnityEngine;
using System.Collections;

public class TileTexture : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		GetComponent<SpriteRenderer>().material.mainTextureScale = new Vector2(transform.localScale.x, transform.localScale.y);
	}
}
