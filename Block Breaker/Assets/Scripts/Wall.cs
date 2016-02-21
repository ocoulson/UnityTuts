using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

	public AudioClip bounce;

	void OnCollisionEnter2D(Collision2D col) {
		AudioSource.PlayClipAtPoint(bounce, transform.position);
	}
}
