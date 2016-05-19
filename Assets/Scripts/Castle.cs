using UnityEngine;
using System.Collections;

public class Castle : MonoBehaviour {

	public GameObject tower;
	public Transform target;
	public float speed = 1f;

	public float maxHealth = 100;
	public float currentHealth;
	private float counter = 0.001f;

	void Start (){
		currentHealth = maxHealth;
	}
	
	void Update (){
		//if (Input.GetKeyDown (KeyCode.Space)) {
		//float step = speed * Time.deltaTime;
		//tower.transform.position = Vector3.MoveTowards(tower.transform.position, target.position, step);
		if (counter > 0 || currentHealth > 0) {
			if(tower.transform.position.y > -1.6){
				float offset = currentHealth / maxHealth * 0.27f;
				tower.transform.position -= new Vector3 (0, (tower.transform.position.y - offset) * 50f, 0) * Time.deltaTime;
				counter -= 1 * Time.deltaTime;
			}
			if(tower.transform.position.y <= -1.6){
				Application.LoadLevel("EndScreen");
			}
		} else {
			if(currentHealth < 0){
				Application.LoadLevel("EndScreen");
			}
			counter = 0;
		}
	}

	public void takeDamage(float damage){
		//while (counter != 0) {	
		currentHealth -= damage;
		//Debug.Log (currentHealth);
		counter += 1f;
		//}
		//segment += .001f * Time.deltaTime;
		//}
		//segment = 0f;
		//if (tower.transform.position.y >= -0.5f) {
		//	tower.transform.position -= new Vector3 (0, .5f, 0); 
		//}
		//tower.transform.position -= new Vector3 (0, 20f, 0) * Time.deltaTime;
	}
}