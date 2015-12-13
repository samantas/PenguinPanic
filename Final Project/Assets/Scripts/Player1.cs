using UnityEngine;
using System.Collections;

public class Player1 : MonoBehaviour {

	[Header("Health")]
	public float currentHealth;
	public float maxHealth;
	public int lives;
	public bool isDead = false;

	[Header("Movement")]
	public float moveSpeed;
	public bool movingLeft;
	public bool movingRight;
	public bool movingUp;
	public bool movingDown;
	public float rotationSpeed;

	[Header("Bullets")]
	public Bullet bullet;
	public bool isShooting;
	public int bulletCounter = 10;
	public bool canShoot = true;
	public float maxBullets1;
	public float bulletPower1;
	public bool bulletReset;
	public bool collectedAmmo = false;
	public int ammo;

	[Header("Enemy")]
	public UpdatedEnemy1 enemy;

	[Header("Music")]
	public AudioSource sfx;
	public AudioClip sfx_gun;
	public AudioClip death;
	public AudioClip sfx_hit;

	public static int player1score;

	void Awake () {
		//player1score = 0;
	}

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
		lives = 3;
		bulletReset = false;
		bulletCounter = 10;
	}
	
	// Update is called once per frame
	void Update () {

		// lives and death
		if (currentHealth <= 0) {
			lives -= 1;
			sfx.clip = death;
			sfx.Play ();

			currentHealth = maxHealth;

			// if player dies, reset bullets
			bulletCounter = 10;
			bulletReset = true;
			canShoot = true;

		} else {
			bulletReset = false;
		}

		if (lives <= 0) {
			//gameObject.SetActive (false);

			isDead = true;
			Player2.player2score += 1;

		} else {
			isDead = false;
		}

		// shoot
		if (Input.GetKeyDown (KeyCode.R) && bulletCounter > 0) {
			Shoot ();
			isShooting = true;
			//sound 
			sfx.clip = sfx_gun;
			sfx.Play();
		} else {
			isShooting = false;
		}

		// don't trigger sound when player shoots but has no bullets
		if (bulletCounter <= 0) {
			isShooting = false;
		}

		// track how many bullets player has used
		if (bulletCounter <= 0) {
			canShoot = false;
		}

		if (bulletCounter > 0) {
			canShoot = true;
		}
		
		// player movement
		// change player movement to addforce
		if (Input.GetKey (KeyCode.W)) {
			transform.position += transform.forward * Time.deltaTime * moveSpeed;
			movingUp = true;
		} else {
			movingUp = false;
		}
		
		if (Input.GetKey (KeyCode.S)) {
			transform.position += -transform.forward * Time.deltaTime * moveSpeed;
			movingDown = true;

		} else {
			movingDown = false;
		}
		
		if (Input.GetKey (KeyCode.A)) {
			// change to rotation
			transform.RotateAround(transform.position, transform.up, -rotationSpeed);
			//transform.position += -transform.right * Time.deltaTime * moveSpeed;
			movingLeft = true;
		} else {
			movingLeft = false;
		}

		if (Input.GetKey (KeyCode.D)) {
			// change to rotation
			transform.RotateAround(transform.position, transform.up, rotationSpeed);
			//transform.position += transform.right * Time.deltaTime * moveSpeed;
			movingRight = true;
		} else {
			movingRight = false;
		}
	}

	void OnCollisionEnter (Collision col){
		
		if (col.collider.tag == "Enemy") {
			currentHealth -= 1;
		}

		if (col.collider.tag == "p2bullet") {
			currentHealth -= bulletPower1;
			// add hit sfx
			sfx.clip = sfx_hit;
			sfx.Play();
		}

		if (col.collider.tag == "EnemyBullet") {
			currentHealth -= 5;
			sfx.clip = sfx_hit;
			sfx.Play();
		}

		// if player colliders with ammo, pick up ammo
		if (col.collider.tag == "Ammo") {
			collectedAmmo = true;
			// destroy that game object
			col.gameObject.SetActive(false);
			bulletCounter += ammo;

		} else {
			collectedAmmo = false;
		}
	}
	
	void Shoot(){

		if (canShoot == true) {

			// instantiate new bullet and set it equal to newBullet
			Bullet newBullet = (Bullet)Instantiate (bullet, transform.position + transform.forward, Quaternion.identity);
			newBullet.direction = transform.forward;
			bulletCounter -= 1;

		} else {

		}

	}
}
