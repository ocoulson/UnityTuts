using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {
	public Slider volumeSlider, difficultySlider;

	public LevelManager levelManager;
	 
	private MusicManager musicManager; 
	// Use this for initialization
	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager>();

		Reset();
	}
	
	// Update is called once per frame
	void Update () {
		musicManager.SetVolume(volumeSlider.value);
	}

	public void SaveAndExit() {
		//Set player prefs via manager
		PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
		PlayerPrefsManager.SetDifficulty(difficultySlider.value);

		//Go back to start
		levelManager.LoadLevel("01a Start");
	}

	public void Reset ()
	{
		volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
		difficultySlider.value = PlayerPrefsManager.GetDifficulty();
	}
	public void SetDefaults() {
		volumeSlider.value = 0.2f;
		difficultySlider.value = 2f;
	}
}
