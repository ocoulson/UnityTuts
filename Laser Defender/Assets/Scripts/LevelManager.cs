using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour {
	private bool paused;
	public void LoadLevel(string name) {
		Debug.Log("Level load requested for " + name);
		SceneManager.LoadScene(name);
	}

	public void QuitRequest() {
		Debug.Log("Recieved quit request");
		Application.Quit();
	}

	void Update () {
		if (paused) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
		if (Input.GetKeyDown (KeyCode.P)) {
			if (paused) {
				paused = false;
			} else {
				paused = true;
			}
		}
	}
}
