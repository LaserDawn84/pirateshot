using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExploder : MonoBehaviour {
	public GameObject explosionEffect;
	public float health = 9f;
	public Transform endMenu;
	[SerializeField]
	public static bool isGameOver = false;
	[SerializeField]
	public static bool isWin = false;
	[SerializeField]
	public static bool isLoss = false;

	void OnCollisionEnter2D(Collision2D collisionData){

		if (collisionData.relativeVelocity.magnitude > health) {
			//if enemy has taken a large hit then die
			Die ();
		}

	}

	void Die(){
		//adds 100 points
		EnemyCollision.pointScore += 100;
		//creates explosion effect
		Instantiate (explosionEffect,transform.position,Quaternion.identity);
		explosionDetonate (); // adds explosion force to near by colliders
		EnemyCollision.enemiesAlive--; //subtracts from alive enemies
		//checks to see if game is over
		if (barrelRotation.ballCount >= 0) {
			if (EnemyCollision.enemiesAlive <= 0) {
				isGameOver = true;
				isWin = true;
				Time.timeScale = 0; //sets game time to 0 effectively pausing it.
				endMenu.gameObject.SetActive(true);
			} else if (barrelRotation.ballCount <= 0 && EnemyCollision.enemiesAlive <= 0) {
				isGameOver = true;
				isLoss = true;
				Time.timeScale = 0;
				endMenu.gameObject.SetActive(true);
			}
		}
		Destroy (gameObject);
	}

	// Use this for initialization
	void Start () {
		EnemyCollision.enemiesAlive++;//on creation enemy counter goes up.
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//explosion function
	void explosionDetonate(){
		//add all colliders in radius of overlap circle to array of collider2d
		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position,5.0f);

		//for each collider add force.
		foreach (Collider2D hit in colliders) {
			Transform t = hit.GetComponent<Transform> ();
			Rigidbody2D rigB = hit.GetComponent<Rigidbody2D> ();
			Vector2 direction = t.transform.position - transform.position;
			rigB.AddForce (direction * 29, ForceMode2D.Impulse);
		}
	}
}
