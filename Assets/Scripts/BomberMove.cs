using UnityEngine;
using System.Collections;

public class BomberMove : MonoBehaviour {

	public float speed = 1;
	public bool movingLeft = true;

	SwipingScript swipeScript;

	Sprite blood;

	Vector3 temp;
	bool dead = false;




	// Use this for initialization
	void Start () {
		swipeScript = FindObjectOfType (typeof(SwipingScript)) as SwipingScript;
		blood = Resources.Load ("blood", typeof(Sprite)) as Sprite;
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

		if (transform.position.y <= -1 && dead == false) {
			gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load ("blood", typeof(Sprite)) as Sprite;
			temp = new Vector3(0,0,0);
			transform.position = temp;
			dead = true;
		}
		Debug.Log ("Transform" + transform.position.x);
	}
}
