using UnityEngine;
using System.Collections;

public class SpeedZoneLeft : MonoBehaviour {
    public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay(Collider other)
    {
        other.attachedRigidbody.AddForce(-transform.right * speed);
    }
}
