using UnityEngine;
using System.Collections;

public class DeathHandler : MonoBehaviour {
    bool flaggedForDeath = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (flaggedForDeath)
        {
            if (this.gameObject.GetComponent<Animator>() != null)
            {
                //this.gameObject.GetComponent<Animator>().Stop(); //halt the walking animation
            }
            if (this.tag == "Enemy")
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("blood", typeof(Sprite)) as Sprite; //make blood puddle
            }
            else if(this.tag == "bomb")
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("EXPLOSION", typeof(Sprite)) as Sprite; //make explosion
                Castle castScript = FindObjectOfType(typeof(Castle)) as Castle;
                castScript.takeDamage();
            }

        }
	
	}

    /// <summary>
    /// Trigger death state in object
    /// </summary>
    public void flagForDeath()
    {
        flaggedForDeath = true;
    }
}
