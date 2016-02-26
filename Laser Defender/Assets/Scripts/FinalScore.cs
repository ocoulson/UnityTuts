using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FinalScore : MonoBehaviour {
	public Text finalScoreText;

	void Start () {
		finalScoreText = GetComponent<Text>();

		finalScoreText.text = ScoreKeeper.score.ToString();

	}

}
