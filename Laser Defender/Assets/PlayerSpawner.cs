﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerSpawner : MonoBehaviour {
	public GameObject playerShip;
	public static int lives = 3;

	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		Debug.Log("Player Spawned");
		SpawnPlayer();
		levelManager = FindObjectOfType<LevelManager>();
	
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
