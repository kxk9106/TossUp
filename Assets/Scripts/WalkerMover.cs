using UnityEngine;
using System.Collections;

public class WalkerMover : MonoBehaviour {
	Castle castScript;
	SwipingScript swipeScript;
	DeathHandler deathScript;
	Shake shakeScript;

	// Use this for initialization
	void Start () {
		castScript = FindObjectOfType (typeof(Castle)) as Castle;
		swipeScript = FindObjectOfType (typeof(SwipingScript)) as SwipingScript;
		deathScript = FindObjectOfType (typeof(DeathHandler)) as DeathHandler;
		shakeScript = FindObjectOfType (typeof(Shake)) as Shake;
		if(this.GetComponent<Rigidbody2D>() == null){
			this.gameObject.AddComponent<Rigidbody2D>();
		}
	}

	// Update is called once per frame
	void Update () {
		//has this charachter been flagged for death? if not, move
		if (!this.GetComponent<SwipingScript>().isDead())
		{
			if(shakeScript.slide == true){
				Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
				
				rb.AddForce(new Vector2(15.0f,0.0f),ForceMode2D.Impulse);
				shakeScript.slide = false;
			}
			else{
				this.transform.position -= new Vector3(2, 0, 0) * Time.deltaTime; /*Time.fixedDeltaTime*/
			}
		}

		//is the character coliding with the castle?
		if (this.transform.position.x <= -4 && !swipeScript.isClickedOn && this.transform.position.x >= -8 && this.transform.position.y <= 4)
		{
			Destroy(this.gameObject);
			castScript.takeDamage(10f);
		}
		//was the character flung clear over the castle.
		else if (this.transform.position.x <= -8 && this.transform.position.y <= 4)
		{
			Destroy(this.gameObject);
		}

		// Increased falling speed when above the screen
		if(this.transform.position.y > 4.2){
			this.GetComponent<Rigidbody2D>().gravityScale = 3;
		} else {
			this.GetComponent<Rigidbody2D>().gravityScale = 1;
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Sky"&&swipeScript.isClickedOn==false && shakeScript.shaking == true) {
			this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
			Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
			rb.AddForce(new Vector2(0.0f,-100.0f),ForceMode2D.Impulse);
			swipeScript.CharacterDead = true;
			shakeScript.shaking = false;
			this.gameObject.GetComponent<BoxCollider2D>().enabled = false;

		}
	}
}