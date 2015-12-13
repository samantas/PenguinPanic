using UnityEngine;
using System.Collections;

public class ThemeSong : MonoBehaviour {

	private static ThemeSong instanceRef;
	
	void Awake() {
	
		if (instanceRef == null) {
			instanceRef = this;
			DontDestroyOnLoad (gameObject);
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
