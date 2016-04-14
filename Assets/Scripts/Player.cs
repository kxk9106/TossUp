using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	Castle castScript;
	SwipingScript swipeScript;

	// Use this for initialization
	void Start () {
		castScript = FindObjectOfType (typeof(Castle)) as Castle;
		swipeScript = FindObjectOfType (typeof(SwipingScript)) as SwipingScript;

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
}