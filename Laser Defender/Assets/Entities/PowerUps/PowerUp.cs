using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {
	public AudioClip spawnSound;

	// Use this for initialization
	void Start () {
		AudioSource.PlayClipAtPoint(spawnSound, transform.position);
	}


}
