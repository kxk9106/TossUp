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

	void Awake(){
	}

	// Use this for initialization
	void Start () {
		lowPassFilterFactor = accelerometerUpdateInterval / lowPassKernelWidthInSecond;
	}
	
	// Update is called once per frame
	void Update () {
		//enemies[0].transform.Translate(Vector3.up * upSpeed * Time.deltaTime,Space.World);

		earthQuake.fillAmount += 1.0f / charge * Time.deltaTime;
		if (earthQuake.fillAmount >= 1) {
			ready.text = "Ready";
		} else {
			ready.text = "";
		}
		iphoneAcc = Input.acceleration;
		iphoneDeltaAcc = iphoneAcc-LowPassFilter(iphoneAcc);
		//Debug.Log ("Iphone: " + iphoneDeltaAcc);
		
		if(Mathf.Abs(iphoneDeltaAcc.x)>=2.5f&&earthQuake.fillAmount == 1.0f)
		{
			earthQuake.fillAmount =.0f;
			Slam ();
		}
		else if(Mathf.Abs(iphoneDeltaAcc.y)>=2.5f&&earthQuake.fillAmount == 1.0f)
		{
			earthQuake.fillAmount =.0f;
			Slam ();
		}
		else if(Mathf.Abs(iphoneDeltaAcc.z)>=2.5f&&earthQuake.fillAmount == 1.0f)
		{
			earthQuake.fillAmount =.0f;
			Slam ();


		}  
	}

	void Slam(){
		enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		Debug.Log ("Enemies: " + enemies.Length);

		foreach(GameObject en in enemies){
			SendUp(en);
			Debug.Log("In the loop");
		}
	}

	void SendUp(GameObject gm){
		if (up == true) {
			gm.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f,3.0f),ForceMode2D.Impulse);
			gm.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
			if(gm.transform.position.y >= 4.0f){
				up = false;
			}
		}
		if (up == false) {
			gm.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f,-40.0f),ForceMode2D.Impulse);
		}
		Debug.Log ("Sent: ");

	}

	Vector3 LowPassFilter(Vector3 newSample) {
		lowPassValue = Vector3.Lerp(lowPassValue, newSample, lowPassFilterFactor);
		return lowPassValue;
	}
}



