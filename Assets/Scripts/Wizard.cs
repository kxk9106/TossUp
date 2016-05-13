using UnityEngine;
using System.Collections;

public class Wizard : MonoBehaviour {

	public GameObject fireballSpawn;
	public GameObject fireballPrefab;
	private Quaternion rot = Quaternion.Euler(0,0,0);


	// Use this for initialization
	void Start () {
		conjure ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void conjure(){
		GameObject ball = (GameObject)Instantiate (fireballPrefab, fireballSpawn.transform.position, rot);
	}
}
