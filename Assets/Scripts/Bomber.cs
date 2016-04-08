using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bomber : MonoBehaviour {

	public float speed = 1;
	
	//for enemy
	public float spawnEnemyEverySeconds = 500f;
	public float enemyStartHeight = 1.5f;
	public GameObject enemyPrefab;
	public List<GameObject> bombers;

	public bool movingLeft = true;

	float tim = 1;
	float distanceThisFrame = 0;
	float spawnAgain = 0;
	float spawnMaybe = 6;

	
	// Use this for initialization
	void Start () {

		//SpawnEnemy ();
	}
	
	// Update is called once per frame
	void Update () {


		distanceThisFrame = tim * Time.deltaTime;
		spawnAgain += distanceThisFrame;

		
		if (spawnAgain > spawnMaybe) {
			SpawnEnemy();
		}

		/*foreach (GameObject bomber in bombers) {
			if (movingLeft) {
				bomber.transform.position += Vector3.left * speed * Time.deltaTime;
				if (bomber.transform.position.x < -2) {
					movingLeft = false;
				}

			} 
			else {
				bomber.transform.position += Vector3.right * speed * Time.deltaTime;
				if(bomber.transform.position.x > 6){
					movingLeft = true;
				}
			}
			Debug.Log ("Transform" + bomber.transform.position.x);
		}*/

		
	}
	
	void SpawnEnemy(){
		spawnAgain = 0;
		GameObject bomber = (GameObject)Instantiate (enemyPrefab, Vector3.up * enemyStartHeight, Quaternion.identity);
		bombers.Add (bomber);
			
	}
}
