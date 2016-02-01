using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NumberWizard : MonoBehaviour {
	int max;
	int min;
	int guess; 
	public Text text;

	int maxGuesses = 10;
	// Use this for initialization
	void Start () {
		StartGame();

	}

	void StartGame () {
		max = 1000;
		min = 1;
		NextGuess();
	}

	public void guessHigher () {
		min = guess;
		NextGuess();
	}

	public void guessLower (){
		max = guess;
		NextGuess();
	}

	void NextGuess ()
	{
		guess = Random.Range (min, max+1);
		text.text = guess.ToString ();
		maxGuesses--;

		} else if (maxGuesses <= 0) {
			SceneManager.LoadScene("Win");
		}
	}
}
