﻿using UnityEngine;
using System.Collections;

public class AnyKey : MonoBehaviour {

	public string sceneName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKey) {
			Application.LoadLevel (sceneName);
		}
	}
}
