﻿using UnityEngine;
using System.Collections;


public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;
	private AudioSource audioSource;

	void Awake() {
		DontDestroyOnLoad(gameObject);
		Debug.Log("Dont destroy on load " + name);
	}
	void Start ()
	{
		audioSource = GetComponent<AudioSource>();
	}

	void OnLevelWasLoaded (int level)
	{
		
		AudioClip thisLevelMusic = levelMusicChangeArray [level];
		if (thisLevelMusic) {
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play();
		}

	}
}
