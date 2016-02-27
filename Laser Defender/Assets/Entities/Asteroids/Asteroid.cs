using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {
	public float health = 1000;
	public int asteroidScore = 100;
	private ScoreKeeper scoreKeeper;

	public AudioClip explosion;

	// Use this for initialization
	void Start () {
		health = health * gameObject.transform.localScale.x; 
		scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D (Collision2D collision)
	{
		Projectile collider = collision.collider.gameObject.GetComponent<Projectile> (); 
		if (collider != null && collider.GetType().Equals(typeof(PlayerProjectile))) {
			health -= collider.getDamage ();
			if (health <= 0) {
				Vector3 pos = transform.position;
				Destroy (gameObject);
				AudioSource.PlayClipAtPoint(explosion, pos);
				scoreKeeper.Score (asteroidScore);
			}
			gameObject.GetComponent<Rigidbody2D> ().velocity += new Vector2 (Random.Range (-0.005f, 0.005f), Random.Range (0.005f, 0.01f));
			collider.Hit ();
		} else if (collider != null && collider.GetType ().Equals(typeof(EnemyProjectile))) {
			health -= collider.getDamage ();
			if (health <= 0) {
				Vector3 pos = transform.position;
				Destroy (gameObject);
				AudioSource.PlayClipAtPoint(explosion, pos);
			}
			gameObject.GetComponent<Rigidbody2D> ().velocity += new Vector2 (Random.Range (-0.005f, 0.005f), Random.Range (0.005f, 0.01f));
			collider.Hit ();
		}


	}

}




