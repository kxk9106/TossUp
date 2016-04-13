using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartButton(string name)
	{
		Debug.Log ("Button");
		Application.LoadLevel(name);
	}
}
