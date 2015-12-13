using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	
	public Vector3 direction;
	public float bulletSpeed;
	private int randomVar;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 5.0f);
	}
	
	// Update is called once per frame
	void Update () {

		transform.position += direction * Time.deltaTime * bulletSpeed;

	}
	
	void OnCollisionEnter(Collision col){
		Debug.Log ("Hit something!!!");
		
		if (col.collider.tag == "Enemy") {
			col.collider.gameObject.SetActive(false);
			Destroy(gameObject);
		}

		if (col.collider.tag == "Player") {
			Destroy (gameObject);
		}
	}
}
