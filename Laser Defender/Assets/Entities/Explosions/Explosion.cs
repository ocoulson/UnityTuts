﻿using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
	private float timer;
	// Use this for initialization
	void Start () {
		timer = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		timer += Time.deltaTime;
		if (timer > 0.25f) {
			Destroy(gameObject);
		}
	}
}
