using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadScene : MonoBehaviour {

	public GameObject panel;
	public Text text;
	public Text objective;
	public Button button;

	private bool loadingScene;
	private bool sceneLoaded;
	private bool keyPressed;

	// Use this for initialization
	void Start () {
		StartCoroutine (WaitToLoad ());
		loadingScene = false;
		sceneLoaded = false;
		keyPressed = false;

		Player1.player1score = 0;
		Player2.player2score = 0;
		objective.text = "";
	}
	
	// Update is called once per frame
	void Update () {

		// add description in to here as well
		if (sceneLoaded && loadingScene) {
			Application.LoadLevel (1);
		}

		if (Input.anyKeyDown) {
			Debug.Log ("anyKeyDown");

			// key pressed = true
			keyPressed = true;

			// hide button image
			button.image.enabled = false;
			button.GetComponentInChildren<Text>().enabled = false;

			//text.text = "Loading...";
			objective.text = "Objective: Find out who you are, who your opponent is, and begin the snowball fight! There " +
				"are three teleports you may use to avoid the other player." + 
				"\n\nLoading...";

		}

		if (sceneLoaded && keyPressed){
			Debug.Log ("Waited for 10 seconds");
			Application.LoadLevel (1);
		}

	}

	// triggered in button onclick events
	public void StartScene(string _sceneName) {

		panel.GetComponent<Image> ().CrossFadeColor (Color.white, 3.0f, false, true); // this isn't working

		//text.text = "Loading...";
		loadingScene = true;

	}

	protected IEnumerator WaitToLoad(){

		yield return new WaitForSeconds (10.0f);
		sceneLoaded = true;

	}
}
