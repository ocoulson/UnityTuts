using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour {

	private bool paused = false;

	public void LoadLevel (string name) {
		SceneManager.LoadScene(name);
		Bricks.breakableCount = 0;
	}

	public void QuitRequest() {
		Debug.Log("Recieved quit request");
		Application.Quit();
	}

	public void LoadNextLevel () {

		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
		Bricks.breakableCount = 0;
	}

	public void BrickDestroyed () {
		if (Bricks.breakableCount <= 0) {
			LoadNextLevel();
		}
	}

	void Update () {
		if (paused) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (paused) {
				paused = false;
			} else {
				paused = true;
			}
		}
	}

	public bool Paused () {
		return paused;
	}
}
