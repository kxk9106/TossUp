using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Shake : MonoBehaviour {

	float lowPassKernelWidthInSecond = 1.0f;
	float accelerometerUpdateInterval = 1.0f / 60.0f;
	float lowPassFilterFactor;
	Vector3 lowPassValue = Vector3.zero;
	Vector3 iphoneAcc;
	Vector3 iphoneDeltaAcc;
	public Image earthQuake;
	float charge = 2.0f;
	public Text ready;
	public GameObject[]enemies;

	public bool shaking = false;

	public float upSpeed = 3.0f;
	public float downSpeed = 4.0f;

	public bool up = true;
	public bool down = false;

	public bool slide = false;
	public float maxProgress = 0.0f;

	void Awake(){
	}

	// Use this for initialization
	void Start () {
		lowPassFilterFactor = accelerometerUpdateInterval / lowPassKernelWidthInSecond;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (earthQuake.fillAmount < maxProgress) {
			earthQuake.fillAmount += .2f * Time.deltaTime;
		} 
		if (earthQuake.fillAmount >= 1) {
			ready.text = "Ready";
		} else {
			ready.text = "";
		}

		iphoneAcc = Input.acceleration;
		iphoneDeltaAcc = iphoneAcc-LowPassFilter(iphoneAcc);

		if(Mathf.Abs(iphoneDeltaAcc.x)>=2.5f&&earthQuake.fillAmount == 1.0f)
		{
			shaking = true;
			earthQuake.fillAmount =.0f;
			maxProgress = 0.0f;
			enemies = GameObject.FindGameObjectsWithTag ("Enemy");

			for(int i = 0; i < enemies.Length; i++){

				Rigidbody2D rb = enemies[i].GetComponent<Rigidbody2D>();
				slide = true;

				//rb.AddForce(new Vector2(30.0f,0.0f),ForceMode2D.Impulse);
				//rb.constraints = RigidbodyConstraints2D.FreezePositionX;
				
			
			}
		}
		else if(Mathf.Abs(iphoneDeltaAcc.y)>=2.5f&&earthQuake.fillAmount == 1.0f)
		{
			earthQuake.fillAmount =.0f;
			maxProgress = 0.0f;

			enemies = GameObject.FindGameObjectsWithTag ("Enemy");

			for(int i = 0; i < enemies.Length; i++){
				Rigidbody2D rb = enemies[i].GetComponent<Rigidbody2D>();

				rb.AddForce(new Vector2(0.0f,25.0f),ForceMode2D.Impulse);
				rb.constraints = RigidbodyConstraints2D.FreezePositionX;
				if (enemies[i].gameObject.GetComponent<Animator>() != null)
				{
					enemies[i].gameObject.GetComponent<Animator>().Stop(); //halt the walking animation
				}
				enemies[i].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("blood", typeof(Sprite)) as Sprite; //make blood puddle

			}
		}
		else if(Mathf.Abs(iphoneDeltaAcc.z)>=2.5f&&earthQuake.fillAmount == 1.0f)
		{
			shaking = true;
			earthQuake.fillAmount =.0f;
			maxProgress = 0.0f;

			enemies = GameObject.FindGameObjectsWithTag ("Enemy");

			for(int i = 0; i < enemies.Length; i++){
				Rigidbody2D rb = enemies[i].GetComponent<Rigidbody2D>();
			

				rb.AddForce(new Vector2(0.0f,30.0f),ForceMode2D.Impulse);
				rb.constraints = RigidbodyConstraints2D.FreezePositionX;
				if (enemies[i].gameObject.GetComponent<Animator>() != null)
				{
					enemies[i].gameObject.GetComponent<Animator>().Stop(); //halt the walking animation
				}
				enemies[i].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("blood", typeof(Sprite)) as Sprite; //make blood puddle

			}
		} 
	}

	Vector3 LowPassFilter(Vector3 newSample) {
		lowPassValue = Vector3.Lerp(lowPassValue, newSample, lowPassFilterFactor);
		return lowPassValue;
	}
}



