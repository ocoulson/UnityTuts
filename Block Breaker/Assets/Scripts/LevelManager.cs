﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name) {
		Debug.Log("Level load requested for " + name);
		SceneManager.LoadScene(name);
	}

	public void QuitRequest() {
		Debug.Log("Recieved quit request");
		Application.Quit();
	}

	public void LoadNextLevel () {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
	}

}
