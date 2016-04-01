using UnityEngine;
using System.Collections;

public class SwipingScript : MonoBehaviour {

	const float CAMERA_FLOOR = -4.2f; // Change this to be ground collision later
	const float GRAVITY = 0.006f; // Keep this low
	Vector3 acceleration; // Not sure if we need this variable
	Vector3 velocity;

	bool isClickedOn = false;

	// For grabbing and letting go math
	Vector2 originPosition;
	Vector2 currentPosition;
	float originTime;

	// Use this for initialization
	void Start () {
	}

	// Keep in mind these OnMouse events trigger before Update()
	void OnMouseDown(){
		if(Input.GetMouseButtonDown(0)){ //Change to Input.GetTouch(0)
			// Simply using Input.mousePosition gives reletive position on screen of testing machine and not reletive to scene
			Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Collider2D hitCollider = Physics2D.OverlapPoint (mousePos);

			// Will it blend? If so, start allowing the OnMouseDrag to call
			if(hitCollider){
				isClickedOn = true;
				originPosition = this.transform.position;
				originTime = Time.time;

				// Stop momentum if player grabs midair
				acceleration = new Vector3(0,0,0);
				velocity = new Vector3(0,0,0);
			}
		}
	}
	
	void OnMouseDrag(){
		if(isClickedOn){
			Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			pz.z = 0;
			currentPosition = pz;
			this.transform.position = pz;
		}
	}

	void OnMouseUp(){
		if(this.transform.position.y > CAMERA_FLOOR){ // If above the bottom of camera, apply gavity
			acceleration += new Vector3(0, -GRAVITY, 0);
		}

		// So basically the faster the player flicks the cube the faster it travels
		// This has its flaws, but it should do for now
		Vector2 diff = currentPosition - originPosition;
		print ("diff: " + diff);
		float mag = diff.magnitude / (Time.time - originTime) / 100;
		Vector2 direction = (currentPosition - originPosition).normalized;
		Vector3 temp = new Vector3(direction.x, direction.y, 0);

		velocity += temp * mag;
	}

	// Update is called once per frame
	void Update () {
		if(this.transform.position.x < -10 || this.transform.position.x > 10){ // Just for resetting cube
			this.transform.position = new Vector3(0,0,0);
			velocity = new Vector3(0,0, 0);
			acceleration = new Vector3(0,-GRAVITY, 0);
		} else if(this.transform.position.y > 20){ // Dont wait this long you lazy bum you have work to do
			this.transform.position = new Vector3(0,0,0);
			velocity = new Vector3(0,0, 0);
			acceleration = new Vector3(0,-GRAVITY, 0);
		}

		if(this.transform.position.y < CAMERA_FLOOR){
			velocity = new Vector3(0,0,0);
			acceleration = new Vector3(0,0, 0);
		}

		velocity += acceleration;
		this.transform.position += velocity;
	}
}
