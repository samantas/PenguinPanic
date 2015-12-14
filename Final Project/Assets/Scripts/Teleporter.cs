using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {
	public Teleporter teleOut1;
	public Teleporter teleOut2;
	//public Transform previous;
	public bool teleported = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter (Collider other){

		Debug.Log (other.gameObject.name);

		if(other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy"){
		
			if (!teleported) {
			
				if (Random.value < 0.5) {
					teleOut1.teleported = true;
					other.transform.position = teleOut1.transform.position;
					other.transform.position += other.transform.up * 0.75f;
				
				
				} else {
					teleOut2.teleported = true;
					other.transform.position = teleOut2.transform.position;
					other.transform.position += other.transform.up * 0.75f;
				
				}
			}
		
		
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if (other.GetComponent<Rigidbody>())
		{
			teleported = false;
		}
	}
	
	
}