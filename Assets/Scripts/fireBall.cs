using UnityEngine;
using System.Collections;

public class fireBall : MonoBehaviour {

	public GameObject target;
	GameManager gameManagerScript;

	// Use this for initialization
	void Start () {
	gameManagerScript = FindObjectOfType (typeof(GameManager)) as GameManager;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position += new Vector3 (1,0,0) * Time.deltaTime;
	//	this.transform.position = Vector3.MoveTowards(target.transform.position, target.transform.position,.001f)  * Time.deltaTime;
	}
}
