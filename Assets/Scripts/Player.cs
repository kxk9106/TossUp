using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	Castle castScript;

	// Use this for initialization
	void Start () {
		castScript = FindObjectOfType (typeof(Castle)) as Castle;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position -= new Vector3 (2, 0, 0) * Time.fixedDeltaTime;
		if (this.transform.position.x <= -4) {
			Destroy(this.gameObject);
			castScript.takeDamage();
		}
	}
}
