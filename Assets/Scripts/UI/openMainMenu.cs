using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class openMainMenu : MonoBehaviour {
	public void openMainMenuOption(){
		//similar to restart, resets all static variables
		EnemyCollision.enemiesAlive = 3;
		EnemyExploder.isGameOver = false;
		EnemyExploder.isWin = false;
		EnemyExploder.isLoss = false;
		Time.timeScale = 1;
		barrelRotation.ballCount = 3;
		EnemyCollision.pointScore = 0;
		SceneManager.LoadScene("menu"); //loads main menu.
	}
}
