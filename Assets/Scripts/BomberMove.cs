using UnityEngine;
using System.Collections;

public class BomberMove : MonoBehaviour {

	public float speed = 1;
	public bool movingLeft = true;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (movingLeft) {
			transform.position += Vector3.left * speed * Time.deltaTime;
			if (transform.position.x < -2) {
				movingLeft = false;
			}
			
		} 
		else {
			transform.position += Vector3.right * speed * Time.deltaTime;
			if(transform.position.x > 6){
				movingLeft = true;
			}
		}
		Debug.Log ("Transform" + transform.position.x);
	}
}
