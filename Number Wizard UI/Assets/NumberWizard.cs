using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
		guess = 500;
		text.text = guess.ToString();
		max = max + 1;
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
		guess = (max + min) / 2;
		text.text = guess.ToString();
		maxGuesses--;
		if (maxGuesses <= 0) {
			Application.LoadLevel("Win");
		}
	}
}
