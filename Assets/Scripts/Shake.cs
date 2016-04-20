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

	// Use this for initialization
	void Start () {
		lowPassFilterFactor = accelerometerUpdateInterval / lowPassKernelWidthInSecond;

	}
	
	// Update is called once per frame
	void Update () {
		earthQuake.fillAmount += 1.0f / charge * Time.deltaTime;
		if (earthQuake.fillAmount >= 1) {
			ready.text = "Ready";
		} else {
			ready.text = "";
		}
	}

	Vector3 LowPassFilter(Vector3 newSample) {
		lowPassValue = Vector3.Lerp(lowPassValue, newSample, lowPassFilterFactor);
		return lowPassValue;
	}
	
	
	void FixedUpdate () {
		
		iphoneAcc = Input.acceleration;
		iphoneDeltaAcc = iphoneAcc-LowPassFilter(iphoneAcc);
		Debug.Log ("Iphone: " + iphoneDeltaAcc);
		
		if(Mathf.Abs(iphoneDeltaAcc.x)>=.7f&&earthQuake.fillAmount == 1.0f)
		{
			earthQuake.fillAmount =.0f;
		}
		if(Mathf.Abs(iphoneDeltaAcc.y)>=.7f&&earthQuake.fillAmount == 1.0f)
		{
			earthQuake.fillAmount =.0f;
		}
		if(Mathf.Abs(iphoneDeltaAcc.z)>=.7f&&earthQuake.fillAmount == 1.0f)
		{
			earthQuake.fillAmount =.0f;
		}      
	}
}



