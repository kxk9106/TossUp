using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class EarthQuake : MonoBehaviour {

	public Image earthQuake;
	float charge = 2.0f;
	public Text ready;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		earthQuake.fillAmount += 1.0f / charge * Time.deltaTime;
		if (earthQuake.fillAmount >= 1) {
			ready.text = "Ready";
		}
	
	}
}
