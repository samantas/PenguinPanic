using UnityEngine;
using System.Collections;

public class Enemy2 : MonoBehaviour {
	
	public float moveSpeed; // how quickly enemies will move, should be identical to the player's moveSpeed
	public float laziness; // how likely an emeny is to not move from 0 to 1
	public float fidelity; // how likely an enemy is to move in the same direction as the player from 0 to 1
	public float jitters; //  how likey an enemy is to move on their own from 0 to 1 (unimplemented)
	
	public Bullet bullet;
	public Player2 player2;
	
	private int forward = 0;
	private int right = 0;
	private int down = 0;
	private int left = 0;

	private int randomVar;

	public float rotationSpeed;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (player2.isShooting && player2.canShoot) {
			Shoot ();
		} else  {
			
		}
		
		// have the enemy follow the player's movement
		// UP
		if (player2.movingUp == true && Random.value < laziness && Random.value < fidelity) {
			forward = 1;
			
		} else {
			forward = -1;
			
		} if (player2.movingUp == false) {
			forward = 0;
		}
		
		// DOWN
		if (player2.movingDown == true) {
			if (Random.value < laziness && Random.value < fidelity) {
				down = 1;
			} else {
				down = -1;
			}
		} if (player2.movingDown == false) {
			down = 0;
		}
		
		// RIGHT
		if (player2.movingRight == true) {
			if (Random.value < laziness && Random.value < fidelity) {
				right = 1;
			} else {
				right = -1;
			}
		} if (player2.movingRight == false) {
			right = 0;
		}
		
		// LEFT
		if (player2.movingLeft == true) {
			if (Random.value < laziness && Random.value < fidelity) {
				left = 1;
			} else {
				left = -1;
			}
			
		} if (player2.movingLeft == false) {
			left = 0;
		}
		
		transform.position += transform.forward * Time.deltaTime * moveSpeed * forward;
		transform.position += -transform.right * Time.deltaTime * moveSpeed * down;
		
		transform.RotateAround(transform.position, transform.up, -rotationSpeed * left);
		transform.RotateAround(transform.position, transform.up, rotationSpeed * right);
		
		
	}
	
	void Shoot(){
		// instantiate new bullet and set it equal to newBullet
		Bullet newBullet = (Bullet) Instantiate (bullet, transform.position + transform.forward, Quaternion.identity);
		newBullet.direction = transform.forward;

//		randomVar = Random.Range (0, 3);
		
//		switch (randomVar) {
//		case 0:
//			newBullet.direction = transform.forward;
//			break;
//			
//		case 1:
//			newBullet.direction = -transform.forward;
//			break;
//			
//		case 2:
//			newBullet.direction = transform.right;
//			break;
//			
//		case 3:
//			newBullet.direction = -transform.right;
//			break;
//		}
	}

	void OnCollisionEnter (Collision col){
		
		if (col.collider.tag == "Bullet") {
			gameObject.SetActive (false);
		}
	}
}