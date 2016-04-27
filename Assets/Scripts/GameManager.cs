using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public GameObject spawn;
	public GameObject enemy;

	public List<GameObject> walkers;

	Quaternion rot = Quaternion.Euler(0,0,0);
	float timer; // 5s for each wave
	bool waveStart = false;

	// Use this for initialization
	void Start () {
		timer = Random.Range(1.0F, 3.0F);
	}
	
	// Update is called once per frame
	void Update () {
		//print(timer);
		if(timer > 0){
			timer -= Time.deltaTime;
		} else {
			GameObject walk = (GameObject)Instantiate (enemy, spawn.transform.position, rot);
			walkers.Add(walk);
			Start();
		}
	}
}
