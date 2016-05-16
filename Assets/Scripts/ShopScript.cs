using UnityEngine;
using System.Collections;

public class ShopScript : MonoBehaviour {
	Castle castScript;
	GameManager gameManagerScript;

	private bool firstWizardBought = false;
	private bool secondWizardBought = false;
	private int expansions = 0;

	void Start(){
		castScript = FindObjectOfType (typeof(Castle)) as Castle;
		gameManagerScript = FindObjectOfType (typeof(GameManager)) as GameManager;
	}

	// Please make these two buttons always availiable to purchase, ive added buying-blocks myself

	// Button for repairing castle to max health
	public void repair(){
		Debug.Log ("Called Repair");

		float difference = castScript.maxHealth - castScript.currentHealth;
		if(difference > 0){ // player needs to have taken damage
			if(gameManagerScript.totalGameScore > difference * 5){ // cant buy if player cannot afford
				gameManagerScript.totalGameScore -= difference * 5;
				castScript.currentHealth = castScript.maxHealth;
			}
		} else { // nothing to repair
			return;
		}
	}

	// Button for increasing max health
	public void expandCastleHealth(){
		float price = 2000 + Mathf.Pow(100,1 + (expansions/10));
		if(gameManagerScript.totalGameScore > price){
			expansions++;
			castScript.maxHealth += 50;
			castScript.currentHealth += 50;
		}
		Debug.Log ("Called expandCastle Health");
	}

	//Buying Wizards for later time :(
}
