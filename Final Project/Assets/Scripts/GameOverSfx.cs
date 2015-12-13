using UnityEngine;
using System.Collections;

public class GameOverSfx : MonoBehaviour {

	public AudioSource gameOverAS;
	public AudioClip gameOverSfx;

	private static GameOverSfx script;

	void Awake(){

		if (script == null) {
			script = this;
			DontDestroyOnLoad(gameObject);
			DontDestroyOnLoad(gameOverAS);
			DontDestroyOnLoad(gameOverSfx);
		} else {
			DestroyImmediate(gameObject);
		}
	}

	// Use this for initialization
	void Start () {
	
	}


	// Update is called once per frame
	void Update () {


	}
}
