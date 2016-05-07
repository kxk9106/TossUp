using UnityEngine;
using System.Collections;

public class DeathHandler : MonoBehaviour {
    bool flaggedForDeath = false;
    bool exploded = false;
	public float value;
	GameManager gameManagerScript;
	Shake shakeScript;

	// Use this for initialization
	void Start () {
		gameManagerScript = FindObjectOfType (typeof(GameManager)) as GameManager;
		shakeScript = FindObjectOfType (typeof(Shake)) as Shake;

	}
	
	// Update is called once per frame
	void Update () {

        if (flaggedForDeath)
        {
            if (this.gameObject.GetComponent<Animator>() != null)
            {
                this.gameObject.GetComponent<Animator>().Stop(); //halt the walking animation
            }
            if (this.tag == "Enemy")
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("blood", typeof(Sprite)) as Sprite; //make blood puddle
            }
            if (this.tag == "Bomber")
            {

				this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("blood", typeof(Sprite)) as Sprite; //make blood puddle
            }
            else if((this.tag == "bomb") && !exploded)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("EXPLOSION", typeof(Sprite)) as Sprite; //make explosion
                
                Castle castScript = FindObjectOfType(typeof(Castle)) as Castle;
                if (this.GetComponent<BoxCollider2D>().IsTouching(castScript.GetComponent<BoxCollider2D>()))
                {
                    castScript.takeDamage();
                }
                this.GetComponent<explosionHandler>().createExplosion(this.transform);


                exploded = true;
                

            }
        }
	}

    /*
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(this + " hit " + other);
    }
    */


    /// <summary>
    /// Trigger death state in object
    /// </summary>
    public void flagForDeath()
    {
        flaggedForDeath = true;
		if (this.tag == "Enemy") {
			shakeScript.maxProgress += .2f;
		} 
		else if (this.tag == "Bomber") {
			shakeScript.maxProgress += .1f;
		}
		gameManagerScript.gamerScore += value;
		gameManagerScript.scoreText.text= "Score: " + gameManagerScript.gamerScore;
		//Debug.Log (gameManagerScript.gamerScore);
    }

    /// <summary>
    /// Returns life/death state.
    /// Returns true if the character is still alive.
    /// </summary>
    /// <returns>bool alive</returns>
    public bool isAlive()
    {
        return !flaggedForDeath;
    }
}
