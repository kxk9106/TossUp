﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position -= new Vector3 (1, 0, 0) * Time.fixedDeltaTime;
	}
}