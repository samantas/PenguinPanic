using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class gameOver : MonoBehaviour {
	
	public Text stats;

	// Use this for initialization
	void Start () {
		stats.text = "and the winner is...";
	}
	
	// Update is called once per frame
	void Update () {

		stats.text = "Player 1: " + Player1.player1score + "\nPlayer 2: " + Player2.player2score;

		// restart game?!?!
		if (Input.GetKeyDown (KeyCode.Space)) {
			Debug.Log ("Space Pressed");
			Application.LoadLevel (1);
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.LoadLevel(0);
			Player1.player1score = 0;
			Player2.player2score = 0;
		}
	
	}
}
