using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour {
	[SerializeField]
	public static int enemiesAlive;
	public Transform endMenu;
	public float health = 9f;

	[SerializeField]
	public static int pointScore = 0;
	void OnCollisionEnter2D(Collision2D collisionData){
		
		if (collisionData.relativeVelocity.magnitude > health) {
			EnemyCollision.enemiesAlive--; //subtracts from alive enemies
			Die (); //calls death function when dead
		}

	}

	void Die(){
		pointScore += 100;
		if (barrelRotation.ballCount >= 0) {
			if (EnemyCollision.enemiesAlive <= 0) {
				EnemyExploder.isGameOver = true;
				EnemyExploder.isWin = true; //checks if winner used to change endscreen text.
				Time.timeScale = 0;
				endMenu.gameObject.SetActive(true);
			} else if (barrelRotation.ballCount <= 0 && EnemyCollision.enemiesAlive <= 0) {
				EnemyExploder.isGameOver = true; //checks if game over to (used to load end menu)
				EnemyExploder.isLoss = true; //checks if loser used to change endscreen text.
				Time.timeScale = 0;
				endMenu.gameObject.SetActive(true);
			}
		}
		Destroy (gameObject); //destroys game object
	}
	// Use this for initialization
	void Start () {
		enemiesAlive++;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
