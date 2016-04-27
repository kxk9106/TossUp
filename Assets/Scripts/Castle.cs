using UnityEngine;
using System.Collections;

public class Castle : MonoBehaviour {

	public GameObject tower;
	public Transform target;
	public float speed = 1f;
	float counter = 0.001f;

	//float segment = 2f;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update ()
	{
		//if (Input.GetKeyDown (KeyCode.Space)) {
		//float step = speed * Time.deltaTime;
		//tower.transform.position = Vector3.MoveTowards(tower.transform.position, target.position, step);
		if (counter > 0) {
			if(tower.transform.position.y > -1.6){
				tower.transform.position -= new Vector3 (0, .1f, 0) * Time.deltaTime;
				counter -= 1 * Time.deltaTime;
			}
			if(tower.transform.position.y <= -1.6){
				Application.LoadLevel("EndScreen");
				//Debug.Log ("Tower Destroyed");
			}
			//Debug.Log ("Tower: " + tower.transform.position.y);

		} else {
			counter = 0;
			//
		}
	}


	//}


	public void takeDamage(){
		//while (counter != 0) {	
		counter += 1.85f;


		//}
		//segment += .001f * Time.deltaTime;
		//}
		//segment = 0f;


		//if (tower.transform.position.y >= -0.5f) {
		//	tower.transform.position -= new Vector3 (0, .5f, 0); 
		//}

		//tower.transform.position -= new Vector3 (0, 20f, 0) * Time.deltaTime;



	}
}