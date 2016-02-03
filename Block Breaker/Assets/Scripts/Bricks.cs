using UnityEngine;
using System.Collections;

public class Bricks : MonoBehaviour {

	public int maxHits;
	private  int totalHits;
	// Use this for initialization
	void Start () {
		totalHits = 0;
	}

	void OnCollisionEnter2D (Collision2D col) {
		print("Hit");
		totalHits++;
	}
	// Update is called once per frame
	void Update () {
	
	}
}
