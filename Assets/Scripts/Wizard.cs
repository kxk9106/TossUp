using UnityEngine;
using System.Collections;

public class Wizard : MonoBehaviour {

	public GameObject fireballSpawn;
	public GameObject fireballPrefab;
	private Quaternion rot = Quaternion.Euler(0,0,0);
	GameManager gameManagerScript;


	public GameObject target;

	// Use this for initialization
	void Start () {
		gameManagerScript = FindObjectOfType (typeof(GameManager)) as GameManager;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			conjure ();
		}
		
	}

	void conjure(){
		int i = 0;
		float closest = 0f;
		foreach (GameObject walker in gameManagerScript.walkers) 
		{
            if (walker != null)
            {
                float temp = Vector3.Distance(this.transform.position, walker.transform.position);

                if (temp > closest)
                {
                    closest = temp;
                    target = walker;
                }

            }
		}

		GameObject ball = (GameObject)Instantiate (fireballPrefab, fireballSpawn.transform.position, rot) as GameObject;

	}
}
