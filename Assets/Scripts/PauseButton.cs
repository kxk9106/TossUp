using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void pauseButton()
	{
		Time.timeScale = 0.0f;
		Debug.Log ("Paused");
	}
}
