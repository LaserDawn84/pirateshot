using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

	public void RestartGame() {
		//resets static variables
		EnemyCollision.enemiesAlive = 3; 
		EnemyExploder.isGameOver = false;
		EnemyExploder.isWin = false;
		EnemyExploder.isLoss = false;
		Time.timeScale = 1;
		barrelRotation.ballCount = 3;
		EnemyCollision.pointScore = 0;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name); // reloads current scene
	}
}
