using UnityEngine;
using System.Collections;

public class SpeedZoneRight : MonoBehaviour {
    
	public float speed;
    
	// Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// null reference ???
    void OnTriggerStay(Collider other)
    {
        other.attachedRigidbody.AddForce(transform.right * speed);
    }
}
