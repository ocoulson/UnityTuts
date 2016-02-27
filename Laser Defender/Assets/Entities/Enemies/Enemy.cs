using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public GameObject projectile;
	public float health = 150f;
	public float projectileSpeed = 10f;
	public int enemyScore = 150;
	public AudioClip shot;
	public AudioClip explosion;


	private ScoreKeeper scoreKeeper;
	private float shotsPerSecond = 0.5f;

	void Start() {
		scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		Projectile beam = col.gameObject.GetComponent<Projectile> ();
		if (beam != null) {
			health -= beam.getDamage ();
			if (health <= 0) {
				Vector3 pos = transform.position;
				Destroy(gameObject);
				AudioSource.PlayClipAtPoint(explosion, pos);
				scoreKeeper.Score(enemyScore);
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

		AudioSource.PlayClipAtPoint(shot, transform.position, 0.2f);
	}
}
 