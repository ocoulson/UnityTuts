using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	//static instance for Singleton DP
	static MusicPlayer instance = null;

	void Awake () {
		//Check if the instance exists and claim it if it does, destroy this if it doesn't
		if (instance != null) {
			Destroy (gameObject);
			Debug.Log("Duplicate MusicPlayer deleted");
		} else {
			GameObject.DontDestroyOnLoad(gameObject);
			instance = this;
		}
	}
	
	// Update is called once per frame 
	void Update () {
	
	}


}
