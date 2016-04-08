using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public GameObject spawn;
	public GameObject enemy;

	public List<GameObject> walkers;

	Quaternion rot = Quaternion.Euler(0,0,0);

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			GameObject walk = (GameObject)Instantiate (enemy, spawn.transform.position, rot);
			walkers.Add(walk);
		}
	}
}
