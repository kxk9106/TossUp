using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject spawn;
	public GameObject enemy;

	Quaternion rot = Quaternion.Euler(0,0,0);

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			GameObject.Instantiate (enemy, spawn.transform.position, rot);
		}
	}
}
