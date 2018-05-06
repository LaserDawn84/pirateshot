using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BallCount : MonoBehaviour {
	public Text ballText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//update ball count 
		ballText.text = "Balls: " + barrelRotation.ballCount;
	}
}
