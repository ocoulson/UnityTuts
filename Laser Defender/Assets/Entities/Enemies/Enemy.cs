using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public GameObject projectile;
	public float health = 150f;
	public float projectileSpeed = 10f;

	private float shotsPerSecond = 0.5f;


	void OnTriggerEnter2D (Collider2D col)
	{
		Projectile beam = col.gameObject.GetComponent<Projectile> ();
		if (beam != null) {
			health -= beam.getDamage ();
			if (health <= 0) {
				Destroy(gameObject);
			}
			beam.Hit();
		}
	}

	void Update ()
	{
		float probability = Time.deltaTime * shotsPerSecond;

		if (Random.value < probability) {
			Fire();
		}


	}

	void Fire ()
	{
		GameObject laser = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
		laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
	}
}
 