using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public GameObject projectile;
	public float health = 150f;
	public float projectileSpeed = 10f;
	public int enemyScore = 150;
	public AudioClip shot;
	public AudioClip explosion;

	public float dropChance = 0.1f;

	private PowerUpSpawner powerSpawner;
	private ScoreKeeper scoreKeeper;
	private float shotsPerSecond = 0.5f;

	void Start() {
		scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
		powerSpawner = GameObject.FindObjectOfType<PowerUpSpawner>();
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		Projectile beam = col.gameObject.GetComponent<Projectile> ();
		if (beam != null) {
			health -= beam.getDamage ();
			if (health <= 0) {
				Die();
			}
			beam.Hit();
		}
	}

	void Die ()
	{
		Vector3 pos = transform.position;
		Destroy (gameObject);
		AudioSource.PlayClipAtPoint (explosion, pos);
		scoreKeeper.Score (enemyScore);

		if (Random.value < dropChance) {
			powerSpawner.SpawnPowerUp(pos);
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
 