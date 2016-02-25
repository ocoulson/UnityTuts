using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {
	public float health = 1000;
	// Use this for initialization
	void Start () {
		health = health * gameObject.transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D (Collision2D collision)
	{
		Projectile collider = collision.collider.gameObject.GetComponent<Projectile>(); 
		if (collider != null) {
			health -= collider.getDamage ();
			if (health <= 0) {
				Destroy(gameObject);
			}
			collider.Hit();
		}
	}

}




