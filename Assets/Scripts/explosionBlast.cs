using UnityEngine;
using System.Collections;

public class explosionBlast : MonoBehaviour {
    public float explosionPower;

	// Use this for initialization
	void Start () {
        //Debug.Log(this.transform.localScale);
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(this.transform.localScale + " and " + explosionPower);
        this.transform.localScale += (new Vector3(explosionPower, explosionPower, explosionPower) * Time.deltaTime);
        explosionPower *= 0.8f;

        if (explosionPower < 0.00104)
        {
            //Debug.Log("destroyed");
            Destroy(this.gameObject);
        }
	}
	
    // returns the explosion power at its current value
    public float currentExplosionapower()
    {
        return explosionPower;
    }

    
}
