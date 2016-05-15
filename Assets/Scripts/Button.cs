using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {
	public void StartButton(string name)
	{
		Debug.Log ("Button");
		Application.LoadLevel(name);
	}
}
