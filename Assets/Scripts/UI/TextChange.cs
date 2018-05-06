using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextChange : MonoBehaviour {

	public Text changeText;
	// Use this for initialization
	void Start () {
		if(EnemyExploder.isWin == true){
			changeText.text = "You Won!";//if winner set text to you won
		}else if(EnemyExploder.isLoss == true){
			changeText.text = "You Lost!"; //if winner set text to you won.
			}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
