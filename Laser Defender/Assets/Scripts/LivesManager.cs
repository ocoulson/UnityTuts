using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour {
	private int lives;

	private Text livesText;
	void Start ()
	{
		lives = PlayerSpawner.lives;
		livesText = GetComponent<Text>();
		livesText.text = lives.ToString();
	}

	void Update() {
		lives = PlayerSpawner.lives;
		livesText.text = lives.ToString();
	}
}
