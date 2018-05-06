using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrelRotation : MonoBehaviour {


	//float cannonAngle;
	//Vector2 direction;
	public GameObject projectile;
	public GameObject projectileClone;
	public Transform endMenu;
	[SerializeField]
	public static int ballCount = 3;
	Vector3 ballSpawn;

	// Use this for initialization
	void Start () {
		ballSpawn = new Vector3 (-5.36f,-0.72f,0f);
	}
	
	// Update is called once per frame
	void Update () {
		//rotates cannon barrel to mouse
		rotateToMousePosition ();
		//checks if balls are empty
		if (ballCount < 1){
			//checks if enemies are all dead
			if (EnemyCollision.enemiesAlive > 0) {
				//waits for 5 seconds
				waitForBall ();
			} else {
				//waits for 5 seconds
				waitForBall ();
			}
		}
		if (Input.GetMouseButtonDown (0)) {
			//fires ball on left mouse click
			fireProjectile ();
		}

	}

	void fixedUpdate(){

	}

	//Sets the cannon barrel's rotation to the arc tangent angle of the mouse position.
	void rotateToMousePosition(){
		//direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; // This was the old method of calculation
		//cannonAngle = Mathf.Atan2(direction.y,direction.x); //The original Arc tangent calculation which was used in transform.rotation = Quaternion.Euler(new Vector3(0,0,cannonAngle)); 
		//Will most likely be using this for the projectile calculation.


		Vector3 mousePosToWorldPoints = Camera.main.ScreenToWorldPoint(Input.mousePosition); //New calculation method using the world position of the mouse
		Vector3 v3 = new Vector3(0,0,Mathf.Clamp(mousePosToWorldPoints.y*3.6f,-60f,80f)); // creates a new vector 3 with x and y set to zero and z set to mouse world position x 3 and clamped in a range between -60 and 80
		// not sure if I should have converted to radians but I'm not working with angles this time, just the default vector floats for x,y,z.
		transform.rotation = Quaternion.Euler(v3); // Set the rotation of the cannon to the Vector3 "v3" calculated two lines above.

	}

	//spawns and fires a cannon ball
	void fireProjectile(){
		if (ballCount >= 1) {
			projectileClone = Instantiate (projectile,ballSpawn,Quaternion.Euler(ballSpawn)) as GameObject;
			projectileClone.GetComponent<Rigidbody2D>().AddForce ((Camera.main.ScreenToWorldPoint(Input.mousePosition) - projectileClone.transform.right).normalized * 35, ForceMode2D.Impulse);
			ballCount--;
		}
	}

	//Enables the ball to hit an enemy before end screen appears. coroutine waits 5 seconds then is run in update if applicable
	IEnumerator waitForBall(){
		yield return new WaitForSeconds (5f);
		EnemyExploder.isGameOver = true;
		EnemyExploder.isLoss = true;
		Time.timeScale = 0;
		endMenu.gameObject.SetActive(true);

	}

}
