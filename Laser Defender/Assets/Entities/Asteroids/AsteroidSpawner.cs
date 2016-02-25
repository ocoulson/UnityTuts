using UnityEngine;
using System.Collections;

public class AsteroidSpawner : MonoBehaviour {

	public float width = 10f;
	public float height = 5f;
	public GameObject[] asteroids;

	private float spawnChance = 0;
	private float timer = 0;
	private float maxX;
	private float minX;
	void OnDrawGizmos ()
	{
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
	}
	// Use this for initialization
	void Start () {
		float zDistance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,zDistance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,zDistance));

		minX = leftMost.x;
		maxX = rightMost.x;
	}
	
	// Update is called once per frame
	void Update ()
	{
		timer += Time.deltaTime;
		SetSpawnChance ();

		float probability = spawnChance * Time.deltaTime;
		if (Random.value < probability) {
			Debug.Log("Asteroid spawned");
			GameObject asteroid = Instantiate(asteroids[Random.Range(0, asteroids.Length-1)], new Vector3(Random.Range(minX, maxX), transform.position.y), Quaternion.identity) as GameObject;
			asteroid.transform.parent = transform;
			asteroid.GetComponent<Rigidbody2D>().velocity = new Vector3 (0, Random.Range(0.000001f, 2f));
		}
	}

	void SetSpawnChance ()
	{
		if (timer > 10 && timer < 11) {
			spawnChance = 0.1f;
		} else if (timer > 20 & timer < 21) {
			spawnChance = 0.2f;
		} else if (timer > 30 & timer < 31) {
			spawnChance = 0.3f;
		}
	}
}
