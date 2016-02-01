using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	public LevelManager levelManager;

	void OnTriggerEnter2D (Collider2D trigger) {
		Debug.Log("Triggered Message");
		levelManager.LoadLevel("Win"); 
	}

	void OnCollisionEnter2D (Collision2D collision) {
		Debug.Log("Collision Message");
	}
}
 