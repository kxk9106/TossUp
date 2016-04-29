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

	public float upSpeed = 3.0f;
	public float downSpeed = 4.0f;

	public bool up = true;
	public bool down = false;

	void Awake(){
	}

	// Use this for initialization
	void Start () {
		lowPassFilterFactor = accelerometerUpdateInterval / lowPassKernelWidthInSecond;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		earthQuake.fillAmount += 1.0f / charge * Time.deltaTime;
		if (earthQuake.fillAmount >= 1) {
			ready.text = "Ready";
		} else {
			ready.text = "";
		}
		iphoneAcc = Input.acceleration;
		iphoneDeltaAcc = iphoneAcc-LowPassFilter(iphoneAcc);

		if(Mathf.Abs(iphoneDeltaAcc.x)>=2.5f&&earthQuake.fillAmount == 1.0f)
		{
			earthQuake.fillAmount =.0f;
			enemies = GameObject.FindGameObjectsWithTag ("Enemy");
			Debug.Log ("Enemies: " + enemies.Length);
			
			for(int i = 0; i < enemies.Length; i++){

				Rigidbody2D rb = enemies[i].GetComponent<Rigidbody2D>();

				rb.AddForce(new Vector2(30.0f,0.0f),ForceMode2D.Impulse);
				rb.constraints = RigidbodyConstraints2D.FreezePositionX;
				
			
			}
		}
		else if(Mathf.Abs(iphoneDeltaAcc.y)>=2.5f&&earthQuake.fillAmount == 1.0f)
		{
			earthQuake.fillAmount =.0f;
			enemies = GameObject.FindGameObjectsWithTag ("Enemy");
			Debug.Log ("Enemies: " + enemies.Length);
			
			for(int i = 0; i < enemies.Length; i++){
				Rigidbody2D rb = enemies[i].GetComponent<Rigidbody2D>();

				rb.AddForce(new Vector2(0.0f,30.0f),ForceMode2D.Impulse);
				rb.constraints = RigidbodyConstraints2D.FreezePositionX;
			}
		}
		else if(Mathf.Abs(iphoneDeltaAcc.z)>=2.5f&&earthQuake.fillAmount == 1.0f)
		{
			earthQuake.fillAmount =.0f;
			enemies = GameObject.FindGameObjectsWithTag ("Enemy");
			Debug.Log ("Enemies: " + enemies.Length);
			
			for(int i = 0; i < enemies.Length; i++){
				Rigidbody2D rb = enemies[i].GetComponent<Rigidbody2D>();
			

				rb.AddForce(new Vector2(0.0f,30.0f),ForceMode2D.Impulse);
				rb.constraints = RigidbodyConstraints2D.FreezePositionX;
			
			}
		} 
	}

	Vector3 LowPassFilter(Vector3 newSample) {
		lowPassValue = Vector3.Lerp(lowPassValue, newSample, lowPassFilterFactor);
		return lowPassValue;
	}
}



