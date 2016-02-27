using UnityEngine;
using System.Collections;

public class PowerUpSpawner : MonoBehaviour {

	public GameObject health1;

	public void SpawnPowerUp (Vector3 position)
	{
		GameObject powerUp = Instantiate (health1, position, Quaternion.identity) as GameObject;
		powerUp.transform.parent = transform;
		powerUp.GetComponent<Rigidbody2D>().velocity += new Vector2(0, -1f);
	}
}
