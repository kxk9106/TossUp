using UnityEngine;
using System.Collections;

public class BomberMove : MonoBehaviour {

	public float speed = 1;
	public bool movingLeft = true;
    public GameObject bombPrefab;
    Quaternion rot = Quaternion.Euler(0, 0, 0);

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
                GameObject bomb = (GameObject)Instantiate(bombPrefab, this.transform.position + new Vector3(0.0f, 0.0f, -0.4f), rot);
                Vector3 temp = new Vector3(Random.Range(-0.01f, -0.11f), -0.06f, 0.0f);
                bomb.GetComponent<SwipingScript>().setVelocity(temp);
                bomb.GetComponent<SwipingScript>().IDbomb(true);
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

		// Increased falling speed when above the screen
		if(this.transform.position.y > 4.2){
			this.GetComponent<Rigidbody2D>().gravityScale = 3;
		} else {
			this.GetComponent<Rigidbody2D>().gravityScale = 0;
		}
	}
}
