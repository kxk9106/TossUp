using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour {

	Castle castle;
	// Use this for initialization
	void Start () {
		castle = GetComponent<Castle> ();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Enemy") {
			//Debug.Log("HI");
			//castle.GetComponent<Castle>().takeDamage();
		}
	}
}