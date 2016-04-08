using UnityEngine;
using System.Collections;

public class Castle : MonoBehaviour {

	public GameObject tower;
	public Transform target;
	public float speed = 1f;
	 float segment = 2f;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		//if (Input.GetKeyDown (KeyCode.Space)) {
		//float step = speed * Time.deltaTime;
		//tower.transform.position = Vector3.MoveTowards(tower.transform.position, target.position, step);

		//takeDamage();
		//}
		//takeDamage ();
	}

	public void takeDamage(){

		/*

		//while (segment < .3839993f) {	
		segment -= Time.deltaTime;
		if (segment > -1.7) {
			tower.transform.position -= new Vector3 (0, .5f, 0) * Time.deltaTime;
		}
			//segment += .001f * Time.deltaTime;
		//}
		//segment = 0f;

		*/
		if (tower.transform.position.y >= -0.5f) {
			tower.transform.position -= new Vector3 (0, .5f, 0); 
		}


	}
}
