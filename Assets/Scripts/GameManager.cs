using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public GameObject spawn;
	public GameObject enemy;

	public List<GameObject> walkers;

	Quaternion rot = Quaternion.Euler(0,0,0);

	const int FIRST_WAVE_COUNT = 10;

	private bool waitForWave = true;
	private float interWaveTimer;
	private float intraSpawnTimer;
	private List<int> waveSpawnCount;
	private int spawnCountLimit = FIRST_WAVE_COUNT; // First wave count
	private int currentSpawnCount = FIRST_WAVE_COUNT;

	// Use this for initialization
	void Start () {
		waveSpawnCount = new List<int>();
		waveSpawnCount.Add(FIRST_WAVE_COUNT);
		resetInterWaveTimer();
		resetIntraSpawnTimer();
	}

	void resetInterWaveTimer(){
		interWaveTimer = 5.0f; // sort of a constant
	}
	
	void resetIntraSpawnTimer(){
		currentSpawnCount--;
		intraSpawnTimer = Random.Range(1.0F, 3.0F);
	}

	// Update is called once per frame
	void Update () {
		if(waitForWave){ // Resting
			if(interWaveTimer > 0){
				interWaveTimer -= Time.deltaTime;
			} else {
				waitForWave = false;
				resetInterWaveTimer();
			}
		} else { // Spawning
			if(intraSpawnTimer > 0){
				intraSpawnTimer -= Time.deltaTime;
			} else {
				GameObject walk = (GameObject)Instantiate (enemy, spawn.transform.position, rot);
				walkers.Add(walk);
				resetIntraSpawnTimer();
				if(currentSpawnCount <= 0){
					if(spawnCountLimit == FIRST_WAVE_COUNT){
						spawnCountLimit = FIRST_WAVE_COUNT * 2;
						waveSpawnCount.Add(spawnCountLimit);
					} else {
						spawnCountLimit = waveSpawnCount[waveSpawnCount.Count - 1] + waveSpawnCount[waveSpawnCount.Count - 2];
						waveSpawnCount.Add(spawnCountLimit);
					}

					currentSpawnCount = spawnCountLimit;
					waitForWave = true;
				}
			}
		}
	}
}
