using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_"; 

	public static void SetMasterVolume (float volume)
	{
		if (volume >= 0f && volume <= 1f) {
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
		} else {
			Debug.LogError("Tried to set volume outside 0-1 range");
		}

	}

	public static float GetMasterVolume() {
		return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
	}

	public static void UnlockLevel (int level)
	{
		if (level <= SceneManager.sceneCountInBuildSettings - 1) {
			 PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1); //Use 1 for true
		} else {
			Debug.Log("Trying to unlock level not in build settings");
		}
	}

	public static bool IsLevelUnlocked (int level)
	{
		if (level <= SceneManager.sceneCountInBuildSettings - 1) {
			int result = PlayerPrefs.GetInt (LEVEL_KEY + level.ToString ()); 
			if (result == 1) {
				return true;
			} else {
				return false;
			}
		} else {
			Debug.Log("Checking level not in build settings");
			return false;
		}

	}

	public static void SetDifficulty (float difficulty)
	{
		if (difficulty >= 1f && difficulty <= 3f) {
			PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
		} else {
			Debug.LogError("Difficulty is out of range 0-5");
		}
	}

	public static float GetDifficulty() {
		return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
	}
}
