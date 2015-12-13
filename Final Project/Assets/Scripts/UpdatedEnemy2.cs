using UnityEngine;
using System.Collections;

public class UpdatedEnemy2 : MonoBehaviour {
	
	public float rotationSpeed; // should be the same as the player rotation speed;
	public float moveSpeed;// how quickly enemies will move, should be identical to the player's moveSpeed
	
	public float laziness;// how likely an emeny is to notmove from 0 to 1
	public float fidelity;// how likely an enemy is to move in the same direction as the player from 0 to 1
	public float jitters;//  how likey an enemy is move on there own from 0 to 1 (unimplemented)
	public float tick= .1f;// the tick length of the jitter AI
	public float minAttentionSpan= 5;//the shortest time in ticks that the AI will wait to make an idependent descion
	public float maxAttentionSpan= 20;//the longest time in ticks that the AI will wait to make an idependent descion
	
	private float moveAttention = 0;
	private float turnAttention = 0;
	private int forward = 0;
	private int turn  = 0;

	public Player2 player2;
	public EnemyBullet bullet;
	
	
	// Use this for initialization
	
	void Start () {
		InvokeRepeating ("Jitter", 0.0f, tick);
	}
	
	void makeRandomMove() {
		if(Random.value < .4){
			forward= 0;
		} else if (Random.value < .5) {
			forward = 1;
		} else {
			forward = -1;
		}
		
	}
	void makeRandomTurn() {
		if(Random.value < .4) {
			turn = 0;
		} else if (Random.value < .5) {
			turn = 1;
		} else {
			turn = -1;
		}
	}
	
	void Jitter() {
		
		if (moveAttention <= 0) {
			moveAttention = Random.Range(minAttentionSpan,maxAttentionSpan);
			if (Random.value<jitters)
			{
				makeRandomMove();
			}
		} else {
			moveAttention--;
		}
		if (turnAttention <= 0) {
			turnAttention = Random.Range(minAttentionSpan/3,maxAttentionSpan/3);
			if (Random.value<jitters)
			{
				makeRandomTurn();
			}
		} else {
			turnAttention--;
		}
	}
	
	// Update is called once per frame
	
	void Update () {
		
		if (player2.isShooting && player2.canShoot) {
			Shoot ();
		} else  {
			
		}
		
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			
			if (Random.value > laziness) {
				
				if (Random.value < fidelity) {
					
					forward = 1;
					
				}
				
				else {
					
					forward = -1;
					
				}
			}
		}
		
		if (Input.GetKeyUp (KeyCode.UpArrow)) {
			
			forward = 0;
			
		}
		
		if (Input.GetKeyDown(KeyCode.DownArrow)) {
			
			if (Random.value > laziness) {
				
				if (Random.value < fidelity) {
					
					forward = -1;
					
				}
				
				else {
					
					forward = 1;
					
				}
			}
		}
		
		if (Input.GetKeyUp (KeyCode.RightArrow)) {
			
			forward = 0;
			
		}
		
		if (Input.GetKeyDown(KeyCode.RightArrow)) {
			
			if (Random.value > laziness) {
				
				if (Random.value < fidelity) {
					
					turn = 1;
					
				}
				
				else {
					
					turn = -1;	
				}
			}
		}
		
		if (Input.GetKeyUp (KeyCode.RightArrow)) {
			
			turn = 0;
			
		}
		
		if (Input.GetKeyUp (KeyCode.RightArrow)) {
			
			forward = 0;
			
		}
		
		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			
			if (Random.value > laziness) {
				
				if (Random.value < fidelity) {
					
					turn = -1;
					
				}
				
				else {
					
					turn = 1;
					
				}
			}
		}
		
		if (Input.GetKeyUp (KeyCode.LeftArrow)) {
			
			turn = 0;
			
		}
		
		transform.position += transform.forward * Time.deltaTime * moveSpeed * forward;
		transform.RotateAround(transform.position, transform.up, rotationSpeed*turn);
		
	}
	
	void Shoot(){
		// instantiate new bullet and set it equal to newBullet
		EnemyBullet newBullet = (EnemyBullet) Instantiate (bullet, transform.position + transform.forward, Quaternion.identity);
		newBullet.direction = transform.forward;
		
	}
	
	void OnCollisionEnter (Collision col){
		
		if (col.collider.tag == "p1bullet") {
			gameObject.SetActive (false);
		}
		
		if (col.collider.tag == "p2bullet") {
			gameObject.SetActive (false);
		}
		
		if (col.collider.tag == "EnemyBullet") {
			gameObject.SetActive (false);
		}
	}
	
}
