using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float playerHealth = 500f;
	public float speed = 15.0f;
	public float padding = 0.5f;
	public float projectileSpeed = 20f; 
	public GameObject projectile;
	public float fireRate = 0.2f;

	private float initialHealth;
	private float maxX;
	private float minX;

	private LevelManager levelManager;

	void Start ()
	{
		levelManager = FindObjectOfType<LevelManager>();

		initialHealth = playerHealth;
		float zDistance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,zDistance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,zDistance));

		minX = leftMost.x + padding;
		maxX = rightMost.x - padding;
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		Projectile enemyLaser = col.gameObject.GetComponent<Projectile> ();
		if (enemyLaser) {
			
			playerHealth -= enemyLaser.getDamage ();
			enemyLaser.Hit();
			if (playerHealth <= 0) {
				Destroy(gameObject);
				levelManager.LoadLevel("Lose");
			}
			Debug.Log("Player Hit, health:" + (playerHealth/initialHealth) * 100 + "%");
		}
	}

	void Fire() {
		GameObject beam = Instantiate(projectile,transform.position, Quaternion.identity) as GameObject;
		beam.GetComponent<Rigidbody2D>().velocity = new Vector3 (0, projectileSpeed);
	}

	void Update ()
	{	 
		MovePlayer ();

		if (Input.GetKeyDown (KeyCode.Space)) {
			InvokeRepeating ("Fire", 0.0000001f, fireRate);	
		}

		if (Input.GetKeyUp (KeyCode.Space)) {
			CancelInvoke();
		}

	}

	void MovePlayer ()
	{
		Vector3 spritePos = this.transform.position;

		bool leftKey = Input.GetKey (KeyCode.LeftArrow);
		bool rightKey = Input.GetKey (KeyCode.RightArrow);


		if (leftKey && !rightKey) {
			
			this.transform.position += Vector3.left * speed * Time.deltaTime;

		} else if (rightKey && !leftKey) {

			this.transform.position += Vector3.right * speed * Time.deltaTime;
		}
	
		float newX = Mathf.Clamp(transform.position.x,minX,maxX);

		transform.position = new Vector3(newX, transform.position.y, transform.position.z); 
//		bool upKey = Input.GetKey (KeyCode.UpArrow);
//		bool downKey = Input.GetKey (KeyCode.DownArrow);
//		if (upKey && !downKey) {
//			this.transform.position += Vector3.up * speed * Time.deltaTime;
//		} else if (downKey && !upKey) {
//			this.transform.position += Vector3.down * speed * Time.deltaTime;
//		}
	}
}
