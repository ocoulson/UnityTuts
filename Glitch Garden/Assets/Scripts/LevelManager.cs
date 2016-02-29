using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour {

	public float autoLoadNextLevelAfter;

	void Start ()
	{
		//Only autoload start screen from splash
		if (autoLoadNextLevelAfter == 0) {
			Debug.Log ("Didn't AutoLoad next level");
		} else {
			Invoke("LoadNextLevel", autoLoadNextLevelAfter); 
		}

	}
	public void LoadLevel(string name) {
		SceneManager.LoadScene(name);
	}

	public void QuitRequest() {
		Debug.Log("Recieved quit request");
		Application.Quit();
	}

	public void LoadNextLevel() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

}
