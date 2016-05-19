using UnityEngine;
using System.Collections;

public class explosionHandler : MonoBehaviour {

    public GameObject explosiveForcePrefab;
    Quaternion rot;


	// Use this for initialization
	void Start () {
        rot = Quaternion.Euler(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /// <summary>
    /// creates an explosion instance at the given transform position
    /// </summary>
    /// <param name="blastOrigin"></param>
    public void createExplosion(Transform blastOrigin)
    {
        GameObject explosion = (GameObject)Instantiate(explosiveForcePrefab, blastOrigin.position, rot);
        //explosion.tag = "explosion";
    }
}
