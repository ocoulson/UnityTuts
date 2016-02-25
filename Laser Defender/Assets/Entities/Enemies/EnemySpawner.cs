using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {

	public GameObject[] enemyPrefab;
	public float width;
	public float height;
	public float spawnDelayTime = 0.5f;
	public static float difficulty = 1;

	private float speed;
	float enemy2Chance = 0.2f * difficulty;
	float enemy3Chance = 0.1f * difficulty;
	float enemy4Chance = 0.05f * difficulty;
	private float leftX;
	private float rightX;
	private bool goingLeft = true;

	// Use this for initialization
	void Start ()
	{
		float zDistance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,zDistance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,zDistance));

		leftX = leftMost.x;
		rightX = rightMost.x;
		//Speed is intially dependent on width of screen.
		speed = (rightX - leftX) / 5f;

		SpawnEnemies();
	}

	void SpawnEnemies ()
	{
		foreach (Transform child in transform) {
			GameObject enemy = Instantiate (enemyPrefab[0], child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
	}

	void SpawnUntilFull ()
	{
		 
		Transform freePos = NextRandomFreePosition ();
		float random = Random.value;
		if (freePos) {
			if (random < enemy4Chance) {
				SpawnEnemy(3, freePos);
			} else if (random < enemy3Chance) {
				SpawnEnemy(2, freePos);
			} else if (random < enemy2Chance) {
				SpawnEnemy(1, freePos);
			} else {
				SpawnEnemy(0, freePos);
			}

		}
		if (NextFreePosition ()) {
			Invoke("SpawnUntilFull", spawnDelayTime);
		}
	}
	void SpawnEnemy (int arrayIndex, Transform freePos)
	{
		GameObject enemy = Instantiate (enemyPrefab [arrayIndex], freePos.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = freePos;
	}

	void OnDrawGizmos ()
	{
		Gizmos.DrawWireCube(transform.position, new Vector3(width,height));
	}
	
	// Update is called once per frame
	void Update ()
	{	
		EnemyMove ();

		if (AllEnemiesDestroyed ()) {
			Debug.Log("Empty Formation");
			difficulty ++;

			SpawnUntilFull();
		}
	}

	Transform NextFreePosition ()
	{
		foreach (Transform childPosition in transform) {
			if (childPosition.childCount == 0) {
				return childPosition;
			}
		}
		return null;
	}

	Transform NextRandomFreePosition ()
	{	
		List<Transform> freePositions = new List<Transform>();

		foreach (Transform childPosition in transform) {
			if (childPosition.childCount == 0) {
				freePositions.Add(childPosition);
			}
		}
		return freePositions[Random.Range(0, freePositions.Count)];
	}

	bool AllEnemiesDestroyed ()
	{
		foreach (Transform childPosition in transform) {
			if (childPosition.childCount > 0) {
				return false;
			}
		}
		return true;
	}

	void EnemyMove ()
	{
		float leftPos = transform.position.x - (width / 2);
		float rightPos = transform.position.x + (width / 2);

		if (goingLeft) {
			transform.position += Vector3.left * speed * Time.deltaTime;
		} else {
			transform.position += Vector3.right * speed * Time.deltaTime;
		}

		if (goingLeft && leftPos <= leftX) {
			goingLeft = false;
		} else if (!goingLeft && rightPos >= rightX) {
			goingLeft = true;
		}
	}
}
