using UnityEngine;
using System.Collections;

public class Life : MonoBehaviour {
	//Singleton
	static Life instance = null;
	public static int lives;
	void awake() {
		if (instance != null) {
			Destroy (gameObject);
		} else {
			GameObject.DontDestroyOnLoad(gameObject);
			instance = this;
			lives = 3;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
