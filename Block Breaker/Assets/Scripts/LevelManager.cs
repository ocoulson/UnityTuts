using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour {

	public void LoadLevel (string name) {
		SceneManager.LoadScene(name);
	}

	public void QuitRequest() {
		Debug.Log("Recieved quit request");
		Application.Quit();
	}

	public void LoadNextLevel () {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
	}

	public void BrickDestroyed () {
		print(Bricks.breakableCount);
		if (Bricks.breakableCount <= 0) {
			LoadNextLevel();
		}
	}
}
