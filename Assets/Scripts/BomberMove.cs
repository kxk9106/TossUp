using UnityEngine;
using System.Collections;

public class BomberMove : MonoBehaviour {

	public float speed = 1;
	public bool movingLeft = true;

	SwipingScript swipeScript;
	
	Vector3 temp;
	bool dead = false;

	// Use this for initialization
	void Start () {
		transform.position = new Vector3(9.0f, transform.position.y, transform.position.z);
		swipeScript = FindObjectOfType (typeof(SwipingScript)) as SwipingScript;
	}
	
	// Update is called once per frame
	void Update () {
		if (movingLeft && dead == false) {
			transform.position += Vector3.left * speed * Time.deltaTime;
			if (transform.position.x < -2) {
				movingLeft = false;
			}
			
		} 
		else if (movingLeft == false && dead == false){
			transform.position += Vector3.right * speed * Time.deltaTime;
			if(transform.position.x > 6){
				movingLeft = true;
			}
		}

		if (transform.position.y <= -2 && dead == false) {
			transform.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load ("blood", typeof(Sprite)) as Sprite;
			//temp = new Vector3(0,0,0);
			//transform.position = temp;
			dead = true;
		}
		//Debug.Log ("Transform" + transform.position.x);
	}
}
