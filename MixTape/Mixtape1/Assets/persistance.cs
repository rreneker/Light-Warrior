﻿using UnityEngine;
using System.Collections;

public class persistance : MonoBehaviour {

	public int score = 0;


	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
