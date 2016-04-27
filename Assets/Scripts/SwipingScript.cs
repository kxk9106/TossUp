using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SwipingScript : MonoBehaviour
{

    const float CAMERA_FLOOR = -4.2f; // Change this to be ground collision later
    const float GRAVITY = 0.006f; // Keep this low
    Vector3 acceleration; // Not sure if we need this variable
    Vector3 velocity;
    Queue<Vector2> fingerTrack = new Queue<Vector2>(); //position queue
    bool CharacterDead = false;
    bool isBomb = false;
	private Animator anim;


    public bool isClickedOn = false;
	public bool grounded = true;

    // Use this for initialization
    public void Start()
    {
        queSetter();
		anim = GetComponent<Animator> ();

    }

    // Keep in mind these OnMouse events trigger before Update()
    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        { //Change to Input.GetTouch(0)
            queSetter();
            // Simply using Input.mousePosition gives relative position on screen of testing machine and not reletive to scene
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hitCollider = Physics2D.OverlapPoint(mousePos);

            // Will it blend? If so, start allowing the OnMouseDrag to call
            if (hitCollider)
            {
                isClickedOn = true;
				grounded = false;

                if (this.gameObject.GetComponent<Animator>() != null)
                {
                    anim.SetBool("Grabbed", (isClickedOn));
                    anim.SetBool("Grounded", (grounded));
                }
				
                // Stop momentum if player grabs midair
                acceleration = Vector3.zero;
                velocity = Vector3.zero;
            }
        }
    }

    void OnMouseDrag()
    {
        if (isClickedOn && Time.timeScale != 0.0f)
        {
            Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pz.z = 0;
            this.transform.position = pz;


            fingerTrack.Enqueue(this.transform.position);//add current finger position to queue
            fingerTrack.Dequeue();//remove the oldest position from the queue
        }
    }

    void OnMouseUp()
    {
		if ((this.transform.position.y > -2) && (Time.timeScale != 0.0f))
		{ // If above the bottom of camera, apply gavity
			acceleration += new Vector3(0, -GRAVITY, 0);
		}

		if ((this.transform.position.y <= -2) && (Time.timeScale != 0.0f))
		{
			grounded = true;
			anim.SetBool ("Grounded", (grounded));
		}

        Vector2[] points = fingerTrack.ToArray();
        //Vector2 startPoint = points[0];
        //Vector2 midPoint = points[1];
        //Vector2 endPoint = points[2];


        // So basically the faster the player flicks the cube the faster it travels
        // This has its flaws, but it should do for now
        // TB update: this averages the last two drag positions. We should consider using the spring
        // system the professor demonstrated if we have the chance.
        Vector2 diff = ((points[1] - points[0]) + (points[2] - points[1])) / 2;








        diff.Scale(new Vector2(0.5f, 0.5f));

        velocity += new Vector3(diff.x, diff.y, 0);
		isClickedOn = false;

        if (this.gameObject.GetComponent<Animator>() != null)
        {
            anim.SetBool("Grabbed", (isClickedOn));
        }
		
    }

    // Update is called once per frame
    void Update()
    {
        /*if (this.transform.position.x < -10 || this.transform.position.x > 10)
        { // Just for resetting cube
            this.transform.position = Vector3.zero;
            velocity = Vector3.zero;
            acceleration = new Vector3(0, -GRAVITY, 0);
        }
        else if (this.transform.position.y > 20)
        { // Dont wait this long you lazy bum you have work to do
            this.transform.position = Vector3.zero;
            velocity = Vector3.zero;
            acceleration = new Vector3(0, -GRAVITY, 0);
        }*/

		if (CharacterDead)
		{
			if(this.GetComponent<SpriteRenderer>().color.a > 0){
				Color color = this.GetComponent<SpriteRenderer>().color;
				color.a -= 0.01f;
				this.GetComponent<SpriteRenderer>().color = color;
			} else {
				Destroy(this.gameObject);
			}
		}

        if (this.transform.position.y < -2/*CAMERA_FLOOR*/)
        {
            //fatal fall speed
            if (this.velocity.magnitude > 0.2f)
            {
                CharacterDead = true;

                if(this.GetComponent<DeathHandler>() != null)
                {
                    this.GetComponent<DeathHandler>().flagForDeath();
                }
                /*
                if (this.gameObject.GetComponent<Animator>() != null)
                {
                    this.gameObject.GetComponent<Animator>().Stop(); //halt the walking animation
                }
                if (!isBomb)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("blood", typeof(Sprite)) as Sprite; //make blood puddle
                }
                else
                {
                    this.GetComponent<DeathHandler>().flagForDeath();
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("EXPLOSION", typeof(Sprite)) as Sprite; //makeexplosion
                    Castle castScript = FindObjectOfType(typeof(Castle)) as Castle;
                    castScript.takeDamage();
                }*/
            }

            velocity = Vector3.zero;
            acceleration = Vector3.zero;
        }

        velocity += acceleration;
        this.transform.position += velocity;
    }

    /// <summary>
    /// resets the queue so old fling actions do not cause odd forcw behavior.
    /// Clears the queue and then adds three new points at the objects location.
    /// </summary>
    void queSetter()
    {
        //clear the old positions from the que
        fingerTrack.Clear();

        //create three new position points at the objects location
        fingerTrack.Enqueue(this.transform.position);
        fingerTrack.Enqueue(this.transform.position);
        fingerTrack.Enqueue(this.transform.position);

    }

    /// <summary>
    /// declares the life or death status of the attatched chracter.
    /// </summary>
    /// <returns>charachter death/life status</returns>
    public bool isDead()
    {
        return CharacterDead;
    }

    /// <summary>
    /// Set the velocity to input.
    /// </summary>
    /// <param name="setFling">fling value</param>
    public void setVelocity(Vector3 setFling)
    {
        acceleration += new Vector3(0, -GRAVITY, 0);
        velocity.Set(setFling.x, setFling.y, 0.0f);    
    }

    /// <summary>
    /// tells the object to behave as a bomb
    /// </summary>
    /// <param name="_isBomb"></param>
    public void IDbomb(bool _isBomb)
    {
        isBomb = _isBomb;
    }
}

