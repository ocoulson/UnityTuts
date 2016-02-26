using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {
	public static int score = 0;

	private Text scoreText;
	void Start ()
	{
		scoreText = GetComponent<Text>();
	}
	public void Score(int points) {
		score += points;
		scoreText.text = score.ToString();
	}

	public void Reset() {
		score = 0;
		scoreText.text = score.ToString();
	}
}
