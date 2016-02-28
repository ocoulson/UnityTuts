using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerSpawner : MonoBehaviour {
	public GameObject playerShip;
	public static int lives = 3;
	public AudioClip explosion;

	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		Debug.Log("Player Spawned");
		SpawnPlayer();
		levelManager = FindObjectOfType<LevelManager>();
		lives = 3;
	
	}

	void OnDrawGizmos ()
	{
		Gizmos.DrawWireCube(transform.position, new Vector3(1f,1f));
	}

	void SpawnPlayer() {
		GameObject player = Instantiate(playerShip, transform.position, Quaternion.identity) as GameObject;
		player.transform.parent = transform;
	}

	public void PlayerDies ()
	{
		lives--;
		AudioSource.PlayClipAtPoint(explosion, transform.position);
		StartCoroutine("Wait");

	}

	IEnumerator Wait ()
	{
		yield return new WaitForSeconds(2f);
		if (lives > 0) {
			SpawnPlayer ();
		} else {
			levelManager.LoadLevel("Lose");
		}
	}

	public void AddLife ()
	{
		lives++;
	}

}
