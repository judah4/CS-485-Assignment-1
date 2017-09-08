using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerCollideGrab : MonoBehaviour
{
    public PlayerControl PlayerControl;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision other) 
    {

        Debug.Log("Collide" + other.gameObject.name);
        
        if (other.gameObject.CompareTag ("Pick Up"))
        {
            
            PlayerControl.AddPickup(other.collider);
            
        }

    }
}
