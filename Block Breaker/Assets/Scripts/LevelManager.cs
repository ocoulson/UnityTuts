using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour {

	void start () {
	}

	public void LoadLevel (string name) {
		SceneManager.LoadScene(name);
	}

	public void QuitRequest() {
		Debug.Log("Recieved quit request");
		Application.Quit();
	}

	private void LoadNextLevel () {

		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
	}

	public void BrickDestroyed () {
		if (Bricks.breakableCount <= 0) {
			LoadNextLevel();
		}
	}
}
