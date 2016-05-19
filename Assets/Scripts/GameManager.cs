using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	// vars to be set in unity
	public GameObject walkerSpawn;
	public GameObject bomberSpawn;
	public GameObject walkerPrefab;
	public GameObject bomberPrefab;

	// vars that shouldnt be set in Unity, but accessed by other scripts
	public List<GameObject> walkers;
	public List<GameObject> bombers;
	public float totalGameScore;
	public Text scoreText;
	
	const int FIRST_WAVE_COUNT = 10;

	private Quaternion rot = Quaternion.Euler(0,0,0);
	private bool waitForWave = true;
	private float interWaveTimer;
	private float intraWalkerSpawnTimer;
	private float intraBomberSpawnTimer;
	private List<int> waveSpawnCount;
	private int spawnCountLimit = FIRST_WAVE_COUNT; // First wave count
	private int currentSpawnCount = FIRST_WAVE_COUNT;
	
	// Use this for initialization
	void Start () {
		waveSpawnCount = new List<int>();
		waveSpawnCount.Add(FIRST_WAVE_COUNT);
		interWaveTimer = 5.0f;
		resetIntraWalkerSpawnTimer();
		resetIntraBomberSpawnTimer();
		totalGameScore = 0;
	}

	void resetInterWaveTimer(){
		interWaveTimer = 10.0f; // sort of a constant
		//print ("Wave " + waveSpawnCount.Count + " Starting!");
	}
	
	void resetIntraWalkerSpawnTimer(){
		currentSpawnCount--;
		intraWalkerSpawnTimer = Random.Range(1.0F, 3.0F);
	}

	void resetIntraBomberSpawnTimer(){
		currentSpawnCount--;
		intraBomberSpawnTimer = Random.Range(3.0F, 5.0F);
	}

	// Update is called once per frame
	void Update () {
		if(waitForWave){ // Resting
			if(interWaveTimer > 0){
				interWaveTimer -= Time.deltaTime;
			} else {
				waitForWave = false;
				resetInterWaveTimer();


				// --- Insert Transition to Shop Code Here ---


			}
		} else { // Spawning

			// Check for walker spawn
			if(intraWalkerSpawnTimer > 0){
				intraWalkerSpawnTimer -= Time.deltaTime;
			} else {
				GameObject walk = (GameObject)Instantiate (walkerPrefab, walkerSpawn.transform.position, rot);
				walkers.Add(walk);
				resetIntraWalkerSpawnTimer();
				// Check for end wave, break out of function and skip bomber check
				if(checkForEndWave()){
					return;
				}
			}

			// Check for bomber spawn
			if(intraBomberSpawnTimer > 0){
				intraBomberSpawnTimer -= Time.deltaTime;
			} else {
				GameObject bomb = (GameObject)Instantiate (bomberPrefab, bomberSpawn.transform.position, rot);
				bombers.Add(bomb);
				resetIntraBomberSpawnTimer();
				checkForEndWave();
			}
		}
	}

		bool checkForEndWave(){
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
				return true;
			}

			return false;
		}
}
