using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	Castle castScript;
	SwipingScript swipeScript;
	DeathHandler deathScript;

	// Use this for initialization
	void Start () {
		castScript = FindObjectOfType (typeof(Castle)) as Castle;
		swipeScript = FindObjectOfType (typeof(SwipingScript)) as SwipingScript;
		deathScript = FindObjectOfType (typeof(DeathHandler)) as DeathHandler;
		if(this.GetComponent<Rigidbody2D>() == null){
			this.gameObject.AddComponent<Rigidbody2D>();
		}

	}

	// Update is called once per frame
	void Update () {

		//has this charachter been flagged for death? if not, move
		if (!this.GetComponent<SwipingScript>().isDead())
		{
            this.transform.position -= new Vector3(2, 0, 0) * Time.deltaTime; /*Time.fixedDeltaTime*/
		}

		//is the character coliding with the castle?
		if (this.transform.position.x <= -4 && !swipeScript.isClickedOn && this.transform.position.x >= -8 && this.transform.position.y <= 4)
		{
			Destroy(this.gameObject);
			castScript.takeDamage();
		}
		//was the character flung clear over the castle.
		else if (this.transform.position.x <= -8 && this.transform.position.y <= 4)
		{
			Destroy(this.gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Sky") {
			Debug.Log ("Hit sky");
			Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
			rb.AddForce(new Vector2(0.0f,-100.0f),ForceMode2D.Impulse);
			this.gameObject.GetComponent<Animator>().Stop(); //halt the walking animation
			this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("blood", typeof(Sprite)) as Sprite; //make blood puddle
			swipeScript.CharacterDead = true;
		}
	}
}