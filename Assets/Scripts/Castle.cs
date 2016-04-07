using UnityEngine;
using System.Collections;

public class Castle : MonoBehaviour {

	public GameObject tower;
	public Transform target;
	public float speed = 1f;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		//if (Input.GetKeyDown (KeyCode.Space)) {
			float step = speed * Time.deltaTime;
			tower.transform.position = Vector3.MoveTowards(tower.transform.position, target.position, step);


		//}
	}
}
