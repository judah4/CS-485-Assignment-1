using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundStick : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        if(collision.rigidbody == null)
            return;

        collision.rigidbody.drag = 100;
        
    }
}
