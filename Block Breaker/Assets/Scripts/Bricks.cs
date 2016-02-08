using UnityEngine;
using System.Collections;

public class Bricks : MonoBehaviour {

	private LevelManager levelManager;

	public int maxHits;
	private  int totalHits;
	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		totalHits = 0;
	}

	void OnCollisionExit2D (Collision2D col) {
		totalHits++;
		if (totalHits >= maxHits) {
			Destroy(gameObject);
		}

	}

	//TODO: Remove this method once game is done
	void SimulateWin () {
		levelManager.LoadNextLevel(); 
	}

}
