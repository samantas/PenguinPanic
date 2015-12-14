using UnityEngine;
using System.Collections;

public class GameOverSfx : MonoBehaviour {

	public AudioSource gameOverAS;
	public AudioClip gameOverSfx;

	public static GameOverSfx script;

	void Awake(){

		if (script == null) {
			script = this;
			DontDestroyOnLoad(this.gameObject);
			DontDestroyOnLoad(this.gameOverAS);
			DontDestroyOnLoad(this.gameOverSfx);
		} else {
			DestroyImmediate(this.gameObject);
		}
	}

	// Use this for initialization
	void Start () {
	
	}


	// Update is called once per frame
	void Update () {


	}
}
