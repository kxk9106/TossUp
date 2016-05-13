using UnityEngine;
using System.Collections;

public class fireBall : MonoBehaviour {

	GameObject target;
	float speed = 2.5f  * Time.deltaTime;
	Wizard wizardScript;

	// Use this for initialization
	void Start () {
		wizardScript = FindObjectOfType (typeof(Wizard)) as Wizard;
		target = wizardScript.target;
	}
	
	// Update is called once per frame
	void Update () {
		//this.transform.position += new Vector3 (1,0,0) * Time.deltaTime;
		if (target != null) {
			this.transform.position = Vector3.MoveTowards (this.transform.position, target.transform.position, speed);
		} else {
			Destroy (this.gameObject);
		}

	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Enemy") {
			Destroy (coll.gameObject);
			Destroy (this.gameObject);
		}
	}
}
